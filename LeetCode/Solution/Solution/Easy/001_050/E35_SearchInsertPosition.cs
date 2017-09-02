namespace Solution.Easy._001_050
{
    public class E35_SearchInsertPosition
    {
        public int SearchInsert(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]>=target)
                {
                    return i;
                }
            }
            return nums.Length;
        }
    }
}
