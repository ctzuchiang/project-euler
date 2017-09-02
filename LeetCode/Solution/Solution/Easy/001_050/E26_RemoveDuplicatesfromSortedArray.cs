using System.Linq;

namespace Solution.Easy._001_050
{
    public class E26_RemoveDuplicatesfromSortedArray
    {
        /// <summary>
        ///     Removes the duplicates and return length.
        /// </summary>
        /// <param name="nums">The int array.</param>
        /// <returns>Length</returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Count() == 0) return 0;
            var i = 0;
            for (var j = 1; j < nums.Count(); j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }

        public int RemoveDuplicates2(int[] nums)
        {
            return nums.Distinct().ToArray().Length;
        }
        
    }
}