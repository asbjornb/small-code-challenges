# Since only ints 0 is special case and negatives are special cases (need 2 to get good solution)
# The max product array at current place in array is either num itself, previous max * currentNum (both positive) or previousMin * currentNum (both negative)

from typing import List

class Solution:
    def maxProduct(self, nums: List[int]) -> int:
        res = nums[0]
        currentMax = 1
        currentMin = 1
        for num in nums:
            tmpMax = currentMax
            currentMax = max(currentMax * num, currentMin * num, num)
            currentMin = min(tmpMax * num, currentMin * num, num)
            res = max(res, currentMax)
        return res

sol = Solution()
print(sol.maxProduct([2,3,-2,4]), "should be 6")
print(sol.maxProduct([-2,0,-1]), "should be 0")
print(sol.maxProduct([2,3,-2,4,-1]), "should be 48")
print(sol.maxProduct([3,-1,4]), "should be 4")
print(sol.maxProduct([2,-5,-2,-4,3]), "should be 24")
