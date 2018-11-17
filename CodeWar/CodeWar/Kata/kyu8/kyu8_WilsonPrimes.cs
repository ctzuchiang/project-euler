namespace CodeWar.Kata.kyu8
{
    public class kyu8_WilsonPrimes
    {
        public bool AmIWilson(int p)
        {
            // Only 3 Wilson primes are known, others must be > 2 * 10^13 which is greater than int.MaxValue.
            return p == 5 || p == 13 || p == 563;
        }

    }
}
