namespace Solution.Easy._001_050
{
    public class E38_CountAndSay
    {
        public string CountAndSay(int n)
        {
            var result = "1";

            while (--n != 0)
            {
                var cur = "";
                for (var i = 0; i < result.Length; i++)
                {
                    var count = 1;
                    while (i + 1 < result.Length && result[i] == result[i + 1])
                    {
                        count++;
                        i++;
                    }
                    cur += count.ToString() + result[i];
                }
                result = cur;
            }

            return result;
        }
    }
}