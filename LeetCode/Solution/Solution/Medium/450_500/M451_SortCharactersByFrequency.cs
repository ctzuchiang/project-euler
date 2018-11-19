using System;
using System.Collections;
using System.Linq;

namespace Solution.Medium._450_500
{
    public class M451_SortCharactersByFrequency
    {
        public string FrequencySort(string s)
        {
            var ht = new Hashtable();

            foreach (var c in s)
            {
                if (!ht.Contains(c))
                {
                    ht.Add(c, 1);
                }
                else
                {
                    ht[c] = (int)ht[c] + 1;
                }
            }

            string result = string.Empty;

            var len = s.Length - ht.Count + 1;
            while (len > 0)
            {
                foreach (DictionaryEntry hs in ht)
                {
                    if ((int)hs.Value == len)
                    {
                        result += new string((char)hs.Key, len);
                    }
                }

                len--;
            }
            return result;
        }

        public string FrequencySort2(string s)
        {
            return new string(s
                .GroupBy(c => c)
                .Select(g => new { Char = g.Key, Count = g.Count() })
                .OrderByDescending(pair => pair.Count)
                .SelectMany(pair => Enumerable.Range(0, pair.Count).Select(c => pair.Char))
                .ToArray()
            );
        }
    }
}
