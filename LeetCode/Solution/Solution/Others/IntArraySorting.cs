using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Solution.Others
{
    public class IntArraySorting
    {
        public int[] ForLoopSorting(int[] nums)
        {
            int a;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        a = nums[i];
                        nums[i] = nums[j];
                        nums[j] = a;
                    }

                }
            }

            return nums;
        }

        public int[] BucketSorting(int[] nums)
        {
            int[] bucket = new int[100];
            int[] result = new int[nums.Length];
            int index = 0;

            foreach (var num in nums)
            {
                bucket[num]++;
            }

            for (int i = 0; i < bucket.Length; i++)
            {
                while (bucket[i] > 0)
                {
                    result[index++] = i;
                    bucket[i]--;
                }
            }

            return result;
        }


        public int[] QuickSorting(int[] nums)
        {
            Sort(ref nums, 0, nums.Length - 1);
            return nums; 
        }

        private void Sort(ref int[] nums, int left, int right)
        {
            int n;
            if (left < right)
            {
                int middle = nums[(left + right) / 2];
                int i = left - 1;
                int j = right + 1;
                while (true)
                {
                    while (nums[++i] < middle) ;

                    while (nums[--j] > middle) ;

                    if (i >= j)
                        break;

                    n = nums[i];
                    nums[i] = nums[j];
                    nums[j] = n;
                }

                Sort(ref nums, left, i - 1);
                Sort(ref nums, j + 1, right);
            }
        }
    }
}
