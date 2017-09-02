namespace Solution.Easy._001_050
{
    public class E9_PalindromeNumber
    {
        /// <summary>
        ///     Determines whether the specified number is palindrome.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///     <c>true</c> if the specified number is palindrome; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPalindrome(int number)
        {
            if (number < 0)
                return false;

            long result = 0;
            var y = number;
            while (y != 0)
            {
                result = result*10 + y%10;
                y /= 10;
            }

            return result == number;
        }
    }
}