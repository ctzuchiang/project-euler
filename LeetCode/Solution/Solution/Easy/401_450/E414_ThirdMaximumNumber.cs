using System;
using System.Linq;

namespace Solution.Easy._401_450
{
    public class E414_ThirdMaximumNumber
    {
        /// <summary>
        ///     Given a non-empty array of integers, return the third maximum number in this array.
        ///     If it does not exist, return the maximum number. The time complexity must be in O(n).
        /// </summary>
        /// <param name="nums">The nums.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int ThirdMax(int[] nums)
        {
            Array.Sort(nums);
            var distinctNums = nums.Distinct().ToArray();
            if (distinctNums.Length == 1)
            {
                return distinctNums[0];
            }
            if (distinctNums.Length == 2)
            {
                return Math.Max(distinctNums[0], distinctNums[1]);
            }

            return distinctNums[distinctNums.Length - 3];
        }
    }
}