namespace project_euler.Maths.Permutations
{
    internal static class CombinationCalculator
    {
        //This method is a bit slower than the one below but clones lists so they aren't muted with each call
        public static IEnumerable<List<T>> GetCombinations<T>(List<T> input, int length) where T : notnull
        {
            foreach (var result in GetCombinationsDanger(input, length))
            {
                yield return new List<T>(result);
            }
        }

        //Yields combinations of the given length from the given set of items.
        //Mutes the same list though so be careful
        //Can make faster version for when the items are already sorted and also if they are comparable
        public static IEnumerable<List<T>> GetCombinationsDanger<T>(List<T> input, int length) where T : notnull
        {
            var output = new List<T>(length);
            var first = input[0];
            var last = input[^1];
            for (var i = 0; i < length; i++)
            {
                output.Add(first);
            }
            var indexDict = new Dictionary<T, int>();
            for (int i = 0; i < input.Count; i++)
            {
                indexDict.Add(input[i], i);
            }

            while (true)
            {
                yield return output;
                var outputIndex = length - 1;
                var inputIndex = indexDict[output[outputIndex]];
                while (inputIndex < input.Count - 1)
                {
                    inputIndex++;
                    output[outputIndex] = input[inputIndex];
                    yield return output;
                }
                do
                {
                    output[outputIndex] = input[0];
                    outputIndex--;
                    if (outputIndex < 0)
                    {
                        yield break;
                    }
                } while (output[outputIndex].Equals(last));
                var inputIndex2 = indexDict[output[outputIndex]];
                output[outputIndex] = input[inputIndex2+1];
            }
        }
    }
}
