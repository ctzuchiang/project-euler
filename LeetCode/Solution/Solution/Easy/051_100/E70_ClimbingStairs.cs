namespace Solution.Easy._051_100
{
    public class E70_ClimbingStairs
    {
        public int ClimbStairs(int n)
        {
            int a = 1, b = 1;
            while (n-- > 0)
                a = (b += a) - a;
            return a;
        }
    }
}
