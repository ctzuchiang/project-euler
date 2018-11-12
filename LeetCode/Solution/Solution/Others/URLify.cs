using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Others
{
    public class URLify
    {
        public string ReplaceSpace(string str, int trueLength)
        {
            string realStr = str.Substring(0, trueLength);
            string result = string.Empty;

            foreach (var s in realStr)
            {
                if (s == ' ')
                {
                    result += "%20";
                    continue;
                }
                result += s;
            }

            return result;
        }
    }
}
