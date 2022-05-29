# Use left, right pointers to kep track of what subarray to search. Use mid=(right+left)/2 and comparison to shrink to left or right half of the array.

from typing import List

def checkCandidate(nums: List[int], index: int) -> bool:
    return nums[index]<nums[index-1]

def findMin(nums: List[int], left, right) -> int:
    if(left==right):
        return nums[left]
    mid = (left + right) // 2
    num = nums[mid]
    if num<nums[mid-1]:
        return num
    else:
        if num>nums[right]:
            return findMin(nums, mid+1, right)
        else:
            return findMin(nums, left, mid-1)

class Solution:
    def findMin(self, nums: List[int]) -> int:
        left, right = 0, len(nums)-1
        if checkCandidate(nums, left): 
            return nums[left]
        if checkCandidate(nums, right): 
            return nums[right]
        return findMin(nums, left, right)


sol = Solution()
print(sol.findMin([3,4,5,1,2]), "should be 1")
print(sol.findMin([4,5,6,7,0,1,2]), "should be 0")
print(sol.findMin([11,13,15,17]), "should be 11")
