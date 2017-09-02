namespace Solution.Easy._001_050
{
    public class E7_ReverseInteger
    {
        /// <summary>
        ///     Reverses the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public int Reverse(int number)
        {
            long result = 0;
            while (number != 0)
            {
                result = result*10 + number%10;
                number /= 10;
            }
            if (result < int.MinValue || result > int.MaxValue)
            {
                return 0;
            }
            return (int) result;
        }
    }
}