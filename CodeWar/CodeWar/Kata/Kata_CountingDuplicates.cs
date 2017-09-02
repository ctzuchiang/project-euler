using System.Linq;

namespace CodeWar.Kata
{
    public class Kata_CountingDuplicates
    {
        public static int DuplicateCount(string str)
        {
            return str.ToLower().GroupBy(x => x).Count(g => g.Count() > 1);
        }
    }
}
