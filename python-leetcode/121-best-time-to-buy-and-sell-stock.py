# Keep track of observed minimum (best buy spot) check if current sell spot beats previous best

from typing import List
class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        result=0
        min = prices[0]
        for num in prices:
            if num - min > result:
                result = num - min
            if num < min:
                min = num
        return result
