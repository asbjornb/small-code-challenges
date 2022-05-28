# Use (hash-) set for O(1) lookup.
# A solution with less space requirements would be to sort and then check adjacent numbers O(n*log(n))

from typing import List
class Solution:
    def containsDuplicate(self, nums: List[int]) -> bool:
        asSet = set()
        for n in nums:
            if n in asSet:
                return True
            asSet.add(n)
        return False
