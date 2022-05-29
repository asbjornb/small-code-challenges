# Greedy - find a locally optimal solution. If previous best local solution > 0 then add it

from typing import List
class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        for i in range(1, len(nums)):
            if nums[i-1] > 0:
                nums[i] = nums[i-1]+nums[i]
        return max(nums)

sol = Solution()
print(sol.maxSubArray([-2,1,-3,4,-1,2,1,-5,4]), "should be 6")
print(sol.maxSubArray([-2,-1]), "should be -1")