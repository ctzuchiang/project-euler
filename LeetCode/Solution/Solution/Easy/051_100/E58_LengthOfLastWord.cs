using System;

namespace Solution.Easy._051_100
{
    public class E58_LengthOfLastWord
    {
        public int LengthOfLastWord(string s)
        {
            s = s.TrimEnd(' ');
            var strArray = s.Split(' ');
            return strArray[strArray.Length - 1].Length;
        }

        public int LengthOfLastWord2(string s)
        {
            s = s.TrimEnd(' ');
            return s.Length - 1 - s.LastIndexOf(' ');
        }
    }
}
