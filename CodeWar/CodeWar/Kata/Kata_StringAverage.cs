namespace CodeWar.Kata
{
    public class Kata_StringAverage
    {
        public static string AverageString(string str)
        {
            if (str == "")
                return "n/a";

            var strArray = str.Split(' ');
            var sum = 0;
            foreach (var s in strArray)
            {
                StringToInt number;
                if (StringToInt.TryParse(s, out number))
                {
                    sum += (int)number;
                }
                else
                {
                    return "n/a";
                }
            }
            var avg = sum / strArray.Length;
            return ((StringToInt)avg).ToString();
        }

        private enum StringToInt
        {
            zero = 0,
            one,
            two,
            three,
            four,
            five,
            six,
            seven,
            eight,
            nine
        }
    }
}
