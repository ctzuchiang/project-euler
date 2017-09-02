using System.Collections.Generic;

namespace Solution.Easy._001_050
{
    public class E13_RomanToInteger
    {
        /// <summary>
        ///     Romans to int.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public int RomanToInt(string input)
        {
            var romanMapping = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

            var result = 0;
            int currentNumber;
            var lastNumger = romanMapping[input[input.Length - 1]];

            for (var i = input.Length - 1; i >= 0; i--)
            {
                currentNumber = romanMapping[input[i]];
                if (lastNumger > currentNumber)
                {
                    result -= currentNumber;
                }
                else
                {
                    lastNumger = currentNumber;
                    result += currentNumber;
                }
            }

            return result;
        }
    }
}