using System;
using System.Collections.Generic;
using System.Text;

namespace FixPolicyAndUpdate
{
    public enum PolEntryType : uint
    {
        REG_NONE = 0,
        REG_SZ = 1,
        REG_EXPAND_SZ = 2,
        REG_BINARY = 3,
        REG_DWORD = 4,
        REG_DWORD_BIG_ENDIAN = 5,
        REG_MULTI_SZ = 7,
        REG_QWORD = 11,
    }

    public class PolEntry : IComparable<PolEntry>
    {
        private List<byte> byteList;

        public PolEntryType Type { get; set; }
        public string KeyName { get; set; }
        public string ValueName { get; set; }

        internal List<byte> DataBytes
        {
            get { return this.byteList; }
        }

        public uint DWORDValue
        {
            get
            {
                byte[] bytes = this.byteList.ToArray();

                switch (this.Type)
                {
                    case PolEntryType.REG_NONE:
                    case PolEntryType.REG_SZ:
                    case PolEntryType.REG_MULTI_SZ:
                    case PolEntryType.REG_EXPAND_SZ:
                        uint result;
                        if (UInt32.TryParse(this.StringValue, out result))
                        {
                            return result;
                        }
                        else
                        {
                            throw new InvalidCastException();
                        }
                    case PolEntryType.REG_DWORD:
                        if (bytes.Length != 4) { throw new InvalidOperationException(); }
                        if (BitConverter.IsLittleEndian == false) { Array.Reverse(bytes); }
                        return BitConverter.ToUInt32(bytes, 0);
                    case PolEntryType.REG_DWORD_BIG_ENDIAN:
                        if (bytes.Length != 4) { throw new InvalidOperationException(); }
                        if (BitConverter.IsLittleEndian == true) { Array.Reverse(bytes); }
                        return BitConverter.ToUInt32(bytes, 0);
                    case PolEntryType.REG_QWORD:
                        if (bytes.Length != 8) { throw new InvalidOperationException(); }
                        if (BitConverter.IsLittleEndian == false) { Array.Reverse(bytes); }
                        ulong lvalue = BitConverter.ToUInt64(bytes, 0);

                        if (lvalue > UInt32.MaxValue || lvalue < UInt32.MinValue)
                        {
                            throw new OverflowException("QWORD value '" + lvalue.ToString() + "' cannot fit into an UInt32 value.");
                        }

                        return (uint)lvalue;
                    case PolEntryType.REG_BINARY:
                        if (bytes.Length != 4) { throw new InvalidOperationException(); }
                        return BitConverter.ToUInt32(bytes, 0);
                    default:
                        throw new Exception("Reached default cast that should be unreachable in PolEntry.UIntValue");
                }
            }
            set
            {
                this.Type = PolEntryType.REG_DWORD;
                this.byteList.Clear();
                byte[] arrBytes = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian == false) { Array.Reverse(arrBytes); }
                this.byteList.AddRange(arrBytes);
            }
        }
        public ulong QWORDValue
        {
            get
            {
                byte[] bytes = this.byteList.ToArray();

                switch (this.Type)
                {
                    case PolEntryType.REG_NONE:
                    case PolEntryType.REG_SZ:
                    case PolEntryType.REG_MULTI_SZ:
                    case PolEntryType.REG_EXPAND_SZ:
                        ulong result;
                        if (UInt64.TryParse(this.StringValue, out result))
                        {
                            return result;
                        }
                        else
                        {
                            throw new InvalidCastException();
                        }
                    case PolEntryType.REG_DWORD:
                        if (bytes.Length != 4) { throw new InvalidOperationException(); }
                        if (BitConverter.IsLittleEndian == false) { Array.Reverse(bytes); }
                        return (ulong)BitConverter.ToUInt32(bytes, 0);
                    case PolEntryType.REG_DWORD_BIG_ENDIAN:
                        if (bytes.Length != 4) { throw new InvalidOperationException(); }
                        if (BitConverter.IsLittleEndian == true) { Array.Reverse(bytes); }
                        return (ulong)BitConverter.ToUInt32(bytes, 0);
                    case PolEntryType.REG_QWORD:
                        if (bytes.Length != 8) { throw new InvalidOperationException(); }
                        if (BitConverter.IsLittleEndian == false) { Array.Reverse(bytes); }
                        return BitConverter.ToUInt64(bytes, 0);
                    case PolEntryType.REG_BINARY:
                        if (bytes.Length != 8) { throw new InvalidOperationException(); }
                        return BitConverter.ToUInt64(bytes, 0);
                    default:
                        throw new Exception("Reached default cast that should be unreachable in PolEntry.ULongValue");
                }
            }
            set
            {
                this.Type = PolEntryType.REG_QWORD;
                this.byteList.Clear();
                byte[] arrBytes = BitConverter.GetBytes(value);
                if (BitConverter.IsLittleEndian == false) { Array.Reverse(arrBytes); }
                this.byteList.AddRange(arrBytes);
            }
        }
        public string StringValue
        {
            get
            {
                byte[] bytes = this.byteList.ToArray();

                StringBuilder sb = new StringBuilder(bytes.Length * 2);

                switch (this.Type)
                {
                    case PolEntryType.REG_NONE:
                        return "";
                    case PolEntryType.REG_MULTI_SZ:
                        string[] mstring = MultiStringValue;
                        for (int i = 0; i < mstring.Length; i++)
                        {
                            if (i > 0) { sb.Append("\\0"); }
                            sb.Append(mstring[i]);
                        }

                        return sb.ToString();
                    case PolEntryType.REG_DWORD:
                    case PolEntryType.REG_DWORD_BIG_ENDIAN:
                    case PolEntryType.REG_QWORD:
                        return this.QWORDValue.ToString();
                    case PolEntryType.REG_BINARY:
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            sb.AppendFormat("{0:X2}", bytes[i]);
                        }

                        return sb.ToString();
                    case PolEntryType.REG_SZ:
                    case PolEntryType.REG_EXPAND_SZ:
                        return UnicodeEncoding.Unicode.GetString(bytes).Trim('\0');
                    default:
                        throw new Exception("Reached default cast that should be unreachable in PolEntry.StringValue");
                }
            }
            set
            {
                if (value == null) { value = String.Empty; }

                this.Type = PolEntryType.REG_SZ;
                this.byteList.Clear();
                this.byteList.AddRange(UnicodeEncoding.Unicode.GetBytes(value + "\0"));
            }
        }
        public string[] MultiStringValue
        {
            get
            {
                byte[] bytes = this.byteList.ToArray();

                switch (this.Type)
                {
                    case PolEntryType.REG_NONE:
                        throw new InvalidCastException("StringValue cannot be used on the REG_NONE type.");
                    case PolEntryType.REG_DWORD:
                    case PolEntryType.REG_DWORD_BIG_ENDIAN:
                    case PolEntryType.REG_QWORD:
                    case PolEntryType.REG_BINARY:
                    case PolEntryType.REG_SZ:
                    case PolEntryType.REG_EXPAND_SZ:
                        return new string[] { this.StringValue };
                    case PolEntryType.REG_MULTI_SZ:
                        List<string> list = new List<string>();

                        StringBuilder sb = new StringBuilder(256);

                        for (int i = 0; i < (bytes.Length - 1); i += 2)
                        {
                            char[] curChar = UnicodeEncoding.Unicode.GetChars(bytes, i, 2);
                            if (curChar[0] == '\0')
                            {
                                if (sb.Length == 0) { break; }
                                list.Add(sb.ToString());
                                sb.Length = 0;
                            }
                            else
                            {
                                sb.Append(curChar[0]);
                            }
                        }

                        return list.ToArray();
                    default:
                        throw new Exception("Reached default cast that should be unreachable in PolEntry.MultiStringValue");
                }
            }
            set
            {
                this.Type = PolEntryType.REG_MULTI_SZ;
                this.byteList.Clear();

                if (value != null)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (i > 0) { this.byteList.AddRange(UnicodeEncoding.Unicode.GetBytes("\0")); }

                        if (value[i] != null)
                        {
                            this.byteList.AddRange(UnicodeEncoding.Unicode.GetBytes(value[i]));
                        }
                    }
                }

                this.byteList.AddRange(UnicodeEncoding.Unicode.GetBytes("\0\0"));
            }
        }
        public byte[] BinaryValue
        {
            get { return this.byteList.ToArray(); }
            set
            {
                this.Type = PolEntryType.REG_BINARY;
                this.byteList.Clear();

                if (value != null)
                {
                    this.byteList.AddRange(value);
                }
            }

        }

        public void SetDWORDBigEndianValue(uint value)
        {
            this.Type = PolEntryType.REG_DWORD_BIG_ENDIAN;
            this.byteList.Clear();
            byte[] arrBytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian == true) { Array.Reverse(arrBytes); }
            this.byteList.AddRange(arrBytes);
        }

        public void SetExpandStringValue(string value)
        {
            this.StringValue = value;
            this.Type = PolEntryType.REG_EXPAND_SZ;
        }

        public PolEntry()
        {
            this.byteList = new List<byte>();
            Type = PolEntryType.REG_NONE;
            KeyName = "";
            ValueName = "";
        }

        ~PolEntry()
        {
            this.byteList = null;
        }

        // IComparable<PolEntry>

        public int CompareTo(PolEntry other)
        {
            int result;

            result = String.Compare(this.KeyName, other.KeyName, StringComparison.OrdinalIgnoreCase);

            if (result != 0) { return result; }

            bool firstSpecial, secondSpecial;

            firstSpecial = this.ValueName.StartsWith("**", StringComparison.OrdinalIgnoreCase);
            secondSpecial = other.ValueName.StartsWith("**", StringComparison.OrdinalIgnoreCase);

            if (firstSpecial == true && secondSpecial == false) { return -1; }
            if (secondSpecial == true && firstSpecial == false) { return 1; }

            return String.Compare(this.ValueName, other.ValueName, StringComparison.OrdinalIgnoreCase);
        }
    }
}
