using System;
using System.Text;

namespace Solution.Easy._051_100
{
    public class E67_AddBinary
    {
        public string AddBinary(string binaryStr1, string binaryStr2)
        {
            StringBuilder sb = new StringBuilder();
            int carry = 0;
            for (int i = binaryStr1.Length - 1, j = binaryStr2.Length - 1; i >= 0 || j >= 0; i--, j--)
            {
                int total = ((i >= 0 ? binaryStr1[i] - '0' : 0) + (j >= 0 ? binaryStr2[j] - '0' : 0)) + carry;
                sb.Insert(0, total == 2 || total == 0 ? '0' : '1');
                carry = total > 1 ? 1 : 0;
            }
            return carry == 1 ? sb.Insert(0, 1).ToString() : sb.ToString();

            //var num1 = Convert.ToInt64(a, 2);
            //var num2 = Convert.ToInt64(b, 2);

            //return Convert.ToString(num1 + num2, 2);
        }
    }
}
