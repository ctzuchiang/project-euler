using System.Linq;

namespace Solution.Easy._001_050
{
    public class E14_LongestCommonPrefix
    {
        /// <summary>
        ///     Longests the common prefix.
        /// </summary>
        /// <param name="strs">The string array.</param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 0)
                return "";

            var result = "";
            for (var i = 0; i < strs[0].Length; i++)
            {
                var s = strs[0][i];
                if (strs.Any(t => i >= t.Length || s != t[i]))
                {
                    break;
                }
                result += s;
            }
            return result;
        }
    }
}