from operator import itemgetter
from typing import List
class Solution:
    def twoSum(self, nums: List[int], target: int) -> List[int]:
        listWithIndex = [(num, index) for index, num in enumerate(nums)]
        listWithIndex.sort(key=itemgetter(0))
        first=0
        last=len(nums)-1
        while True:
            result=listWithIndex[first][0]+listWithIndex[last][0]
            if result==target:
                break
            elif result>target:
                last -= 1
            else:
                first += 1
        
        return [listWithIndex[first][1], listWithIndex[last][1]]

sol = Solution()
print(sol.twoSum([2,7,11,15], 9))
