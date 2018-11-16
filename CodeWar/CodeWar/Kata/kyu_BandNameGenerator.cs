using System.Linq;

namespace CodeWar.Kata
{
    public class kyu_BandNameGenerator
    {
        public static string BandNameGenerator(string str)
        {
            if (str[0] == str[str.Length - 1])
            {
                return FirstLetterToUppercase(str) + string.Join("", str.Skip(1));
            }
            return "The " + FirstLetterToUppercase(str);
        }

        private static string FirstLetterToUppercase(string str)
        {
            return str.First().ToString().ToUpper() + str.Substring(1, str.Length - 1);
        }
    }
}
