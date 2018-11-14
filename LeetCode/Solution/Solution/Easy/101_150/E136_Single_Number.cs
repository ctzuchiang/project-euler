using System;
using System.Collections;

namespace Solution.Easy._101_150
{
    public class E136_Single_Number
    {
        public int SingleNumber(int[] nums)
        {
            var ht = new Hashtable();
            foreach (int n in nums)
            {
                if (ht.Contains(n))
                {
                    ht[n] = (int)ht[n] + 1;
                }
                else
                {
                    ht.Add(n, 1);
                }
            }

            foreach (DictionaryEntry de in ht)
            {
                if ((int)de.Value == 1)
                {
                    return (int) de.Key;
                }
            }
            throw new ArgumentException("Not found");
        }
    }
}
