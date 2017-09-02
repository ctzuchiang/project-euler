namespace Solution.Easy._001_050
{
    public class E28_Implement_strStr
    {
        /// <summary>
        ///     Find index of string position.
        /// </summary>
        /// <param name="haystack">The haystack.</param>
        /// <param name="needle">The needle.</param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            var hayStackLength = haystack.Length;

            var needleLength = needle.Length;

            if (haystack == needle)
            {
                return 0;
            }

            if (needleLength == 0)
            {
                return 0;
            }

            if (hayStackLength == 0)
            {
                return -1;
            }

            for (var i = 0; i < hayStackLength; i++)
            {
                if (needleLength > hayStackLength - i)
                {
                    return -1;
                }

                if (haystack[i] == needle[0])
                {
                    var j = 0;
                    for (; j < needleLength; j++)
                    {
                        if (needle[j] != haystack[i + j])
                        {
                            break;
                        }
                    }

                    if (j == needleLength && needle[j - 1] == haystack[i + j - 1])
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public int StrStr2(string haystack, string needle)
        {
            return haystack.IndexOf(needle);
        }
    }
}