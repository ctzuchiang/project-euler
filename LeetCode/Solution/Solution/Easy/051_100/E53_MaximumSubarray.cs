using System.Linq;

namespace Solution.Easy._051_100
{
    public class E53_MaximumSubarray
    {
        public int MaxSubArray(int[] nums)
        {
            var sum = 0;
            var fn_1 = 0;
            foreach (var num in nums)
            {
                if (num > 0)
                {
                    fn_1 += num;
                }
                if (fn_1 > sum)
                {
                    sum = fn_1;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
