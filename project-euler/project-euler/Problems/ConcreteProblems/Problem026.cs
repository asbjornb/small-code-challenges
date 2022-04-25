using System.Numerics;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem026 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindLargestRecurring().ToString();
        }

        private static int FindLargestRecurring()
        {
            var maxRecursionLength = 6; //Example of 7 from the problem description
            var maxRecursionCandidate = 7;
            for (int i = 999; i > 1; i--)
            {
                var multiplier = BigInteger.Pow(10, 3*(i+1));
                var decimalRepresentation = multiplier / i; //Using a large multiplier push this into integer territory
                //Discarding first part to make sure to hold cycles - see 1/6 = 0.1666... so we need to discard the 1 before looking for cycles
                var recursionLength = GetRecursionLength(decimalRepresentation.ToString()[i..]);
                if (recursionLength > maxRecursionLength)
                {
                    maxRecursionLength = recursionLength;
                    maxRecursionCandidate = i;
                }
                //Division by i has at most i-1 non-zero remainders so doing long division must cycle before that.
                if(maxRecursionLength>=i)
                {
                    break;
                }
            }
            return maxRecursionCandidate;
        }

        public static int GetRecursionLength(string decimalRepresentation)
        {
            var maxLength = decimalRepresentation.Length / 2;
            for (int i = 0; i < maxLength; i++)
            {
                var candidateToSearch = decimalRepresentation + decimalRepresentation.Substring(i, maxLength);
                var matchAt = candidateToSearch.IndexOf(decimalRepresentation, 1);
                if (matchAt!=-1 && matchAt < decimalRepresentation.Length-1 && matchAt<=maxLength)
                {
                    return matchAt;
                }
            }
            return 1;
        }
    }
}
