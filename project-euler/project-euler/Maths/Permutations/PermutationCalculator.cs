namespace project_euler.Maths.Permutations
{
    internal static class PermutationCalculator
    {
        public static IEnumerable<int[]> GetPermutations(int[] input)
        {
            var clone = (int[])input.Clone();
            Array.Sort(clone);
            yield return clone;
            while (true)
            {
                clone = NextPermutation(clone);
                if (clone == null)
                {
                    yield break;
                }
                yield return clone;
            }
        }

        public static int[]? NextPermutation(int[] numList)
        {
            var result = (int[])numList.Clone();
            return NextPermutationDanger(result) ? result : null;
        }

        //Fast, still fast (but x5'ish slower) if it clones and returns next array or null instead of muting input
        public static bool NextPermutationDanger(int[] numList)
        {
            /*
             Knuth
             1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
             2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
             3. Swap a[j] with a[l].
             4. Reverse the sequence from a[j + 1] up to and including the final element a[n].
             */
            var largestIndex = -1;
            for (var i = numList.Length - 2; i >= 0; i--)
            {
                if (numList[i] < numList[i + 1])
                {
                    largestIndex = i;
                    break;
                }
            }

            if (largestIndex < 0) return false;

            var largestIndex2 = -1;
            for (var i = numList.Length - 1; i >= 0; i--)
            {
                if (numList[largestIndex] < numList[i])
                {
                    largestIndex2 = i;
                    break;
                }
            }

            (numList[largestIndex], numList[largestIndex2]) = (numList[largestIndex2], numList[largestIndex]);

            for (int i = largestIndex + 1, j = numList.Length - 1; i < j; i++, j--)
            {
                (numList[i], numList[j]) = (numList[j], numList[i]);
            }

            return true;
        }
    }
}
