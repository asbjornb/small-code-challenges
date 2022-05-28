from typing import List
class Solution:
    def containsDuplicate(self, nums: List[int]) -> bool:
        asSet = set()
        for n in nums:
            if n in asSet:
                return True
            asSet.add(n)
        return False
