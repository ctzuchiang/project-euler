using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FixPolicyAndUpdate
{
    public class PolFile
    {
        private enum PolEntryParseState
        {
            Key,
            ValueName,
            Start
        }

        private static readonly uint PolHeader = 0x50526567;
        private static readonly uint PolVersion = 0x01000000;

        private Dictionary<string, PolEntry> entries;

        public List<PolEntry> Entries
        {
            get
            {
                List<PolEntry> pl = new List<PolEntry>(entries.Values);
                pl.Sort();

                return pl;
            }
        }

        public string FileName { get; set; }

        public PolFile()
        {
            this.FileName = "";
            this.entries = new Dictionary<string, PolEntry>(StringComparer.OrdinalIgnoreCase);
        }

        public void SetValue(PolEntry pe)
        {
            this.entries[pe.KeyName + "\\" + pe.ValueName] = pe;
        }

        public void SetStringValue(string key, string value, string data)
        {
            this.SetStringValue(key, value, data, false);
        }

        public void SetStringValue(string key, string value, string data, bool bExpand)
        {
            PolEntry pe = new PolEntry();
            pe.KeyName = key;
            pe.ValueName = value;

            if (bExpand)
            {
                pe.SetExpandStringValue(data);
            }
            else
            {
                pe.StringValue = data;
            }

            this.SetValue(pe);
        }

        public void SetDWORDValue(string key, string value, uint data)
        {
            this.SetDWORDValue(key, value, data, true);
        }

        public void SetDWORDValue(string key, string value, uint data, bool bLittleEndian)
        {
            PolEntry pe = new PolEntry();
            pe.KeyName = key;
            pe.ValueName = value;

            if (bLittleEndian)
            {
                pe.DWORDValue = data;
            }
            else
            {
                pe.SetDWORDBigEndianValue(data);
            }

            this.SetValue(pe);
        }

        public void SetQWORDValue(string key, string value, ulong data)
        {
            PolEntry pe = new PolEntry();
            pe.KeyName = key;
            pe.ValueName = value;

            pe.QWORDValue = data;

            this.SetValue(pe);
        }

        public void SetMultiStringValue(string key, string value, string[] data)
        {
            PolEntry pe = new PolEntry();
            pe.KeyName = key;
            pe.ValueName = value;

            pe.MultiStringValue = data;

            this.SetValue(pe);
        }

        public void SetBinaryValue(string key, string value, byte[] data)
        {
            PolEntry pe = new PolEntry();
            pe.KeyName = key;
            pe.ValueName = value;

            pe.BinaryValue = data;

            this.SetValue(pe);
        }

        public PolEntry GetValue(string key, string value)
        {
            PolEntry pe = null;
            this.entries.TryGetValue(key + "\\" + value, out pe);
            return pe;
        }

        public void DeleteContainer(string path)
        {
            var keys = this.entries.Keys.ToArray();
            foreach (var key in keys)
            {
                if (key.Contains(path))
                {
                    this.entries.Remove(key);
                }
            }
        }

        public string GetStringValue(string key, string value)
        {
            PolEntry pe = this.GetValue(key, value);
            if (pe == null) { throw new ArgumentOutOfRangeException(); }

            return pe.StringValue;
        }

        public string[] GetMultiStringValue(string key, string value)
        {
            PolEntry pe = this.GetValue(key, value);
            if (pe == null) { throw new ArgumentOutOfRangeException(); }

            return pe.MultiStringValue;
        }

        public uint GetDWORDValue(string key, string value)
        {
            PolEntry pe = this.GetValue(key, value);
            if (pe == null) { throw new ArgumentOutOfRangeException(); }

            return pe.DWORDValue;
        }

        public ulong GetQWORDValue(string key, string value)
        {
            PolEntry pe = this.GetValue(key, value);
            if (pe == null) { throw new ArgumentOutOfRangeException(); }

            return pe.QWORDValue;
        }

        public byte[] GetBinaryValue(string key, string value)
        {
            PolEntry pe = this.GetValue(key, value);
            if (pe == null) { throw new ArgumentOutOfRangeException(); }

            return pe.BinaryValue;
        }

        public bool Contains(string key, string value)
        {
            return (this.GetValue(key, value) != null);
        }

        public bool Contains(string key, string value, PolEntryType type)
        {
            PolEntry pe = this.GetValue(key, value);
            return (pe != null && pe.Type == type);
        }

        public PolEntryType GetValueType(string key, string value)
        {
            PolEntry pe = this.GetValue(key, value);
            if (pe == null) { throw new ArgumentOutOfRangeException(); }
            return pe.Type;
        }

        public void DeleteValue(string key, string value)
        {
            if (this.entries.ContainsKey(key + "\\" + value) == true) this.entries.Remove(key + "\\" + value);
        }

        public void LoadFile()
        {
            this.LoadFile(null);
        }

        public void LoadFile(string file)
        {
            if (!string.IsNullOrEmpty(file)) { this.FileName = file; }

            byte[] bytes;
            int nBytes = 0;

            using (FileStream fs = new FileStream(this.FileName, FileMode.Open, FileAccess.Read))
            {
                // Read the source file into a byte array. 
                bytes = new byte[fs.Length];
                int nBytesToRead = (int)fs.Length;
                while (nBytesToRead > 0)
                {
                    // Read may return anything from 0 to nBytesToRead. 
                    int n = fs.Read(bytes, nBytes, nBytesToRead);

                    // Break when the end of the file is reached. 
                    if (n == 0) break;

                    nBytes += n;
                    nBytesToRead -= n;
                }

                fs.Close();
            }

            // registry.pol files are an 8-byte fixed header followed by some number of entries in the following format:
            // [KeyName;ValueName;<type>;<size>;<data>]
            // The brackets, semicolons, KeyName and ValueName are little-endian Unicode text.
            // type and size are 4-byte little-endian unsigned integers.  Size cannot be greater than 0xFFFF, even though it's
            // stored as a 32-bit number.  type will be one of the values REG_SZ, etc as defined in the Win32 API.
            // Data will be the number of bytes indicated by size.  The next 2 bytes afterward must be unicode "]".
            // 
            // All strings (KeyName, ValueName, and data when type is REG_SZ or REG_EXPAND_SZ) are terminated by a single
            // null character.
            //
            // Multi strings are strings separated by a single null character, with the whole list terminated by a double null.

            if (nBytes < 8) { throw new FileFormatException(); }

            int header = (bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3];
            int version = (bytes[4] << 24) | (bytes[5] << 16) | (bytes[6] << 8) | bytes[7];

            if (header != PolFile.PolHeader || version != PolFile.PolVersion) { throw new FileFormatException(); }

            var parseState = PolEntryParseState.Start;
            int i = 8;

            var keyName = new StringBuilder(50);
            var valueName = new StringBuilder(50);
            uint type = 0;
            int size = 0;

            while (i < (nBytes - 1))
            {
                char[] curChar = UnicodeEncoding.Unicode.GetChars(bytes, i, 2);

                switch (parseState)
                {
                    case PolEntryParseState.Start:
                        if (curChar[0] != '[') { throw new FileFormatException(); }
                        i += 2;
                        parseState = PolEntryParseState.Key;
                        continue;
                    case PolEntryParseState.Key:
                        if (curChar[0] == '\0')
                        {
                            if (i > (nBytes - 4)) { throw new FileFormatException(); }
                            curChar = UnicodeEncoding.Unicode.GetChars(bytes, i + 2, 2);
                            if (curChar[0] != ';') { throw new FileFormatException(); }

                            // We've reached the end of the key name.  Switch to parsing value name.

                            i += 4;
                            parseState = PolEntryParseState.ValueName;
                        }
                        else
                        {
                            keyName.Append(curChar[0]);
                            i += 2;
                        }
                        continue;
                    case PolEntryParseState.ValueName:
                        if (curChar[0] == '\0')
                        {
                            if (i > (nBytes - 16)) { throw new FileFormatException(); }
                            curChar = UnicodeEncoding.Unicode.GetChars(bytes, i + 2, 2);
                            if (curChar[0] != ';') { throw new FileFormatException(); }

                            // We've reached the end of the value name.  Now read in the type and size fields, and the data bytes
                            type = (uint)(bytes[i + 7] << 24 | bytes[i + 6] << 16 | bytes[i + 5] << 8 | bytes[i + 4]);
                            if (Enum.IsDefined(typeof(PolEntryType), type) == false) { throw new FileFormatException(); }

                            curChar = UnicodeEncoding.Unicode.GetChars(bytes, i + 8, 2);
                            if (curChar[0] != ';') { throw new FileFormatException(); }

                            size = bytes[i + 13] << 24 | bytes[i + 12] << 16 | bytes[i + 11] << 8 | bytes[i + 10];
                            if ((size > 0xFFFF) || (size < 0)) { throw new FileFormatException(); }

                            curChar = UnicodeEncoding.Unicode.GetChars(bytes, i + 14, 2);
                            if (curChar[0] != ';') { throw new FileFormatException(); }

                            i += 16;

                            if (i > (nBytes - (size + 2))) { throw new FileFormatException(); }
                            curChar = UnicodeEncoding.Unicode.GetChars(bytes, i + size, 2);
                            if (curChar[0] != ']') { throw new FileFormatException(); }

                            PolEntry pe = new PolEntry();
                            pe.KeyName = keyName.ToString();
                            pe.ValueName = valueName.ToString();
                            pe.Type = (PolEntryType)type;

                            for (int j = 0; j < size; j++)
                            {
                                pe.DataBytes.Add(bytes[i + j]);
                            }

                            this.SetValue(pe);

                            i += size + 2;

                            keyName.Length = 0;
                            valueName.Length = 0;
                            parseState = PolEntryParseState.Start;
                        }
                        else
                        {
                            valueName.Append(curChar[0]);
                            i += 2;
                        }
                        continue;
                    default:
                        throw new Exception("Unreachable code");
                }
            }
        }

        public void SaveFile()
        {
            this.SaveFile(null);
        }

        public void SaveFile(string file)
        {
            if (!string.IsNullOrEmpty(file)) { this.FileName = file; }

            // Because we maintain the byte array for each PolEntry in memory, writing back to the file
            // is a simple operation, creating entries of the format:
            // [KeyName;ValueName;type;size;data] after the fixed 8-byte header.
            // The only things we must do are add null terminators to KeyName and ValueName, which are
            // represented by C# strings in memory, and make sure Size and Type are written in little-endian
            // byte order.

            using (FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write))
            {
                fs.Write(new byte[] { 0x50, 0x52, 0x65, 0x67, 0x01, 0x00, 0x00, 0x00 }, 0, 8);
                byte[] openBracket = UnicodeEncoding.Unicode.GetBytes("[");
                byte[] closeBracket = UnicodeEncoding.Unicode.GetBytes("]");
                byte[] semicolon = UnicodeEncoding.Unicode.GetBytes(";");
                byte[] nullChar = new byte[] { 0, 0 };

                byte[] bytes;

                foreach (PolEntry pe in this.Entries)
                {
                    fs.Write(openBracket, 0, 2);
                    bytes = UnicodeEncoding.Unicode.GetBytes(pe.KeyName);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Write(nullChar, 0, 2);

                    fs.Write(semicolon, 0, 2);
                    bytes = UnicodeEncoding.Unicode.GetBytes(pe.ValueName);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Write(nullChar, 0, 2);

                    fs.Write(semicolon, 0, 2);
                    bytes = BitConverter.GetBytes((uint)pe.Type);
                    if (BitConverter.IsLittleEndian == false) { Array.Reverse(bytes); }
                    fs.Write(bytes, 0, 4);

                    fs.Write(semicolon, 0, 2);
                    byte[] data = pe.DataBytes.ToArray();
                    bytes = BitConverter.GetBytes((uint)data.Length);
                    if (BitConverter.IsLittleEndian == false) { Array.Reverse(bytes); }
                    fs.Write(bytes, 0, 4);

                    fs.Write(semicolon, 0, 2);
                    fs.Write(data, 0, data.Length);
                    fs.Write(closeBracket, 0, 2);
                }
                fs.Close();
            }
        }
    }
}