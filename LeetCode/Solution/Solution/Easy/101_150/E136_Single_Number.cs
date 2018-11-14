namespace Solution.Easy._101_150
{
    public class E136_Single_Number
    {
        public int SingleNumber(int[] nums)
        {
            int a = 0;
            foreach (int n in nums)
            {
                a ^= n;
            }

            return a;
        }
    }
}
