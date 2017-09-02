using System;
using System.Text;

namespace Solution
{
    public class StringBuilderCleaner
    {
        private readonly int _LoopCount;
        private readonly string _AppendString;

        public StringBuilderCleaner(int loopCount, string appendString)
        {
            _LoopCount = loopCount;
            _AppendString = appendString;
        }

        private StringBuilder sb_Looper()
        {
            StringBuilder sb = new StringBuilder();
            for (int j = 0; j < _LoopCount; j++)
            {
                sb.Append(_AppendString);
            }
            return sb;
        }

        public void StringBuilder_Clear()
        {
            for (int i = 0; i < _LoopCount; i++)
            {
                var sb = sb_Looper();
                sb.Clear();
            }
            Console.Write("Clear      :");
        }

        public void StringBuilder_Remove()
        {
            for (int i = 0; i < _LoopCount; i++)
            {
                var sb = sb_Looper();
                sb.Remove(0, sb.Length);
            }
            Console.Write("Remove     :");
        }

        public void StringBuilder_Replace()
        {
            for (int i = 0; i < _LoopCount; i++)
            {
                var sb = sb_Looper();
                string s = sb.ToString();
                sb.Replace(s, "");
            }
            Console.Write("Replace    :");
        }

        public void StringBuilder_Length_0()
        {
            for (int i = 0; i < _LoopCount; i++)
            {
                var sb = sb_Looper();
                sb.Length = 0;
            }
            Console.Write("Length = 0 :");
        }
    }
}