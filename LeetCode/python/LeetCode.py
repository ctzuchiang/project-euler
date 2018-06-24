class Solution:
    def twoSum(self, nums, target):
        """
        :type nums: List[int]
        :type target: int
        :rtype: List[int]
        """
        
        for i in range(0,len(nums)-1):
            for j in range(i+1,len(nums)-1):
                if nums[i] + nums[j] == target:
                    return list([i,j])

        return list([0,0])
