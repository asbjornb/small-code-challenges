using project_euler.Maths.Primes.Generation;

namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem027 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindBestQuadraticPrimes().ToString();
        }

        //Notes:
        //b divides n^2+an+b for n=b so max consequtive primes for any (a,b) is b
        //b must be prime - else the first term with (n=0) is not prime
        //for n=1 we have 1+a+b and since 1 and b are uneven, a must be too for that term to be prime (well 2, but uneven n then).
        
        //A rough implementation might then be:
        //find all primes below b
        //loop over those primes from top and down
        //loop over a's in range
        //break when b is lower than best example. Certainly when b below 41 as shown in example.
        //This is a brute force approach with roughly 1000*168 quadratic expressions to check for consequtive primes which is again a check up to size b.
        private static int FindBestQuadraticPrimes()
        {
            var bestCoefficients = (a:1,b:41);
            var mostConsequtivePrimes = 40;
            var bCandidates = ListOfPrimes.Construct().GetPrimesBelow(1000).Reverse();
            var listOfPrimes = ListOfPrimes.Construct().GetPrimesBelow(2000000); //n<b<1000 so n^2<1000000 and an<1000000 and b<10000
            foreach (var b in bCandidates)
            {
                for (int a = -999; a < 1000; a+=2)
                {
                    for (int n = 0; n < b; n++)
                    {
                        if (!listOfPrimes.Contains((n * n) + (a * n) + b))
                        {
                            break;
                        }
                        if (n> mostConsequtivePrimes)
                        {
                            mostConsequtivePrimes = n;
                            bestCoefficients = (a, b);
                        }
                    }
                }
                if (b <= mostConsequtivePrimes)
                {
                    break;
                }
            }
            return bestCoefficients.a * bestCoefficients.b;
        }
    }
}
