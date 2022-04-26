using project_euler.Maths.Primes.Generation;

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
                    if (i<3 && IsPrime(increment)) //i=3 is the odd-squares diagonal
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

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i*i <= number; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
