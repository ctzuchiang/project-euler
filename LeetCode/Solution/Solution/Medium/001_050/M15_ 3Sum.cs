using System;
using System.Collections.Generic;

namespace Solution.Medium._001_050
{
    public class M15_3Sum
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();

            if (nums.Length < 3)
                return result;

            Array.Sort(nums);

            for (int first = 0; first < nums.Length - 2; first++)
            {
                int second = first + 1;
                int third = nums.Length - 1;

                if (first != 0 && nums[first] == nums[first - 1])
                {
                    continue;
                }

                while (second < third)
                {
                    if (second > first + 1 && nums[second] == nums[second - 1])
                    {
                        second++;
                        continue;
                    }

                    int sum = nums[first] + nums[second] + nums[third];

                    if (sum == 0)
                    {
                        result.Add(new List<int>()
                        {
                            nums[first],
                            nums[second],
                            nums[third]
                        });
                        second++;
                        third--;
                    }
                    else if (sum > 0)
                    {
                        third--;
                    }
                    else
                    {
                        second++;
                    }
                }
            }

            return result;
        }
    }
}
