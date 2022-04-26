using project_euler.Maths.Primes;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem058 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindCornerPrimeRatio().ToString();
        }

        //Notes: (See also 28)
        //Observe that moving between corners just adds the same number to each corner and moving out a layer adds 2 to height/width.
        private static double FindCornerPrimeRatio()
        {
            var primes = 0;
            var increment = 1;
            var layer = 2;
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    increment += 2 * (layer - 1);
                    if (i<3 && PrimesCalculator.IsPrime(increment)) //i=3 is the odd-squares diagonal
                    {
                        primes++;
                    }
                }
                var ratio = primes / (((double)4 * (layer - 1)) + 1);
                if (ratio < 0.1)
                {
                    //Console.WriteLine("Increment: " + increment);
                    return (2 * layer) - 1;
                }
                layer++;
            }
        }
    }
}
