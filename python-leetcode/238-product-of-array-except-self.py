# Create products on subarrays from both left and right. Then use product to the left and product to the right

from typing import List
class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        fromLeft = [nums[0]]
        fromRight = [nums[-1]]
        for i in range(1, len(nums)):
            fromLeft.append(fromLeft[i-1]*nums[i])
            fromRight.append(fromRight[i-1]*nums[-i-1])
        result = []
        for i in range(len(nums)):
            temp = 1
            if i>0:
                temp *= fromLeft[i-1]
            if i<len(nums)-1:
                temp *= fromRight[-i-2]
            result.append(temp)
        return result

sol = Solution()
print(sol.productExceptSelf([1,2,3,4]))
