# Sort and keep pointers to increase or decrease sum. Watch for duplicates

from typing import List
class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        result = set()
        nums.sort()
        for i in range(len(nums)):
            if(i>0 and nums[i]==nums[i-1]):
                continue
            left, right=i+1, len(nums)-1
            while left<right:
                current = nums[i]+nums[left]+nums[right]
                if(current == 0):
                    result.add((nums[i],nums[left],nums[right]))
                    left += 1    
                elif(current > 0):
                    right -= 1
                elif(current < 0):
                    left += 1
        return [list(t) for t in result]

sol = Solution()
print(sol.threeSum([-1,0,1,2,-1,-4]), "should be [[-1,-1,2],[-1,0,1]]")
print(sol.threeSum([-2,-1,3]), "should be [[-2,-1,3]]")