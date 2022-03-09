namespace project_euler.Maths.Primes
{
    internal class PrimeFactorization
    {
        private readonly Dictionary<int, int> primeFactors;

        public PrimeFactorization()
        {
            primeFactors = new();
        }

        public PrimeFactorization(List<PrimeFactor> factors)
        {
            primeFactors = new();
            foreach (PrimeFactor factor in factors)
            {
                primeFactors.Add(factor.Prime, factor.Exponent);
            }
        }

        public void AddFactor(int prime)
        {
            if (primeFactors.ContainsKey(prime))
            {
                primeFactors[prime]++;
            }
            else
            {
                primeFactors.Add(prime, 1);
            }
        }

        public void AddFactor(PrimeFactor factor)
        {
            if (primeFactors.ContainsKey(factor.Prime))
            {
                primeFactors[factor.Prime] += factor.Exponent;
            }
            else
            {
                primeFactors.Add(factor.Prime, factor.Exponent);
            }
        }

        //Should this be public here or live somewhere else?
        public void IncreaseIfLarger(PrimeFactor factor)
        {
            if (!primeFactors.ContainsKey(factor.Prime))
            {
                primeFactors.Add(factor.Prime, factor.Exponent);
            }
            else
            {
                primeFactors[factor.Prime] = Math.Max(factor.Exponent, primeFactors[factor.Prime]);
            }
        }

        public Dictionary<int, int> ToDict()
        {
            return new Dictionary<int, int>(primeFactors);
        }

        public List<PrimeFactor> ToList()
        {
            return primeFactors.Select(factor => new PrimeFactor(factor.Key, factor.Value)).ToList();
        }

        public bool Compare(PrimeFactorization other)
        {
            var otherDict = other.ToDict();
            return primeFactors.Count == otherDict.Count && !primeFactors.Except(otherDict).Any();
        }

        public long Product()
        {
            long product = 1L;
            foreach (var (prime, exponent) in primeFactors)
            {
                product *= Pow(prime, exponent);
            }
            return product;
        }

        private static int Pow(int baseNum, int exponent)
        {
            var result = baseNum;
            for (int i = 1; i < exponent; i++)
            {
                result *= baseNum;
            }
            return result;
        }
    }
}
