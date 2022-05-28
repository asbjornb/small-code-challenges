# Greedy - find a locally optimal solution

from typing import List
class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        # Preprocess
        sums = [nums[0]]
        for i in range(1, len(nums)):
            if sums[i-1] > 0: # If a previous sub-array has positive sum we can add it to the current number for a better one
                sums.append(sums[i-1]+nums[i])
            else:
                sums.append(nums[i])
        # Return max
        return max(sums)

sol = Solution()
print(sol.maxSubArray([-2,1,-3,4,-1,2,1,-5,4]))
print(sol.maxSubArray([-2,-1]))