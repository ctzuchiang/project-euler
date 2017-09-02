using System;
using System.Linq;

namespace Solution.Easy._001_050
{
    public class E27_RemoveElement
    {
        /// <summary>
        ///     Removes the element and return length.
        /// </summary>
        /// <param name="nums">The int array.</param>
        /// <param name="val">The remove value.</param>
        /// <returns>Length</returns>
        public int RemoveElement(int[] nums, int val)
        {
            int i = 0;
            for (int j = 0; j < nums.Count(); j++)
            {
                if (nums[j] != val)
                {
                    nums[i] = nums[j];
                    i++;
                }
            }
            return i;
        }

        public int RemoveElement2(int[] nums, int val)
        {
            return nums.Count() - nums.Count(num => num == val);
        }
    }
}