using project_euler.Maths.Permutations;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem032 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return SumPandigitalProducts().ToString();
        }

        private static int SumPandigitalProducts()
        {
            var pandigitalProducts = new HashSet<int>();
            var pandigital = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; //Will be muted
            while (PermutationCalculator.NextPermutationDanger(pandigital))
            {
                //Denote a x b = c where a<b (we need to find products so we just decide on order)
                //Assume c <1000 then digits(a)+digits(b)=6. Even with digits(a)=1, digits(b)=5 this doesn't work so c>=1000
                //By the same logic c<10,000 since c>=10.000 would leave 4 digits for a and b. And 99*99<10,000
                //Due to pandigital (no same digits) c must be between 1234 and 9876.
                //then we must have digits(a)+digits(b)=5 so digits(a,b) in (1,4) or (2,3)
                var product = (pandigital[5] * 1000) + (pandigital[6] * 100) + (pandigital[7] * 10) + pandigital[8];
                var multiplicand1 = pandigital[0];
                var multiplier1 = (pandigital[1] * 1000) + (pandigital[2] * 100) + (pandigital[3] * 10) + pandigital[4];
                var multiplicand2 = (pandigital[0] * 10) + pandigital[1];
                var multiplier2 = (pandigital[2] * 100) + (pandigital[3] * 10) + pandigital[4];
                if (multiplicand1 * multiplier1 == product || multiplicand2 * multiplier2 == product)
                {
                    pandigitalProducts.Add(product);
                }
            }
            return pandigitalProducts.Sum();
        }
    }
}
