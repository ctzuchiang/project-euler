namespace CodeWar.Kata._8kyu
{
    public class Kata_ReversedSequence
    {
        public int[] ReverseSeq(int n)
        {
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                result[i] = n - i;
            }

            return result;
        }
    }
}
