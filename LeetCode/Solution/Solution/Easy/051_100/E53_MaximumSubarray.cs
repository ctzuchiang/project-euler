using System;

namespace Solution.Easy._051_100
{
    public class E53_MaximumSubarray
    {
        public int MaxSubArray(int[] nums)
        {
            var sum = 0;
            var max = Int32.MinValue;
            foreach (int num in nums)
            {
                if (sum < 0)
                    sum = num;
                else
                    sum += num;
                if (sum>max)
                    max = sum;
            }
            return max;
        }
    }
}
