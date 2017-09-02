namespace Solution.Easy._001_050
{
    public class E1_TwoSum
    {
        /// <summary>
        ///     Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        ///     You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// </summary>
        /// <param name="nums">The nums.</param>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public int[] Sum(int[] nums, int target)
        {
            for (var i = 0; i <= nums.Length; i++)
            {
                for (var j = i + 1; j <= nums.Length - 1; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] {i, j};
                    }
                }
            }

            return new int[] {};
        }
    }
}