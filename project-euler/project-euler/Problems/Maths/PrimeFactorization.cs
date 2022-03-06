namespace project_euler.Maths
{
    internal class PrimeFactorization
    {
        private readonly Dictionary<int,int> primeFactors;

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

        public int Product()
        {
            var product = 1;
            foreach(var (prime,exponent) in primeFactors)
            {
                product *= Pow(prime,exponent);
            }
            return product;
        }

        private static int Pow(int baseNum, int exponent)
        {
            var result = baseNum;
            int i = 1;
            while (i<exponent)
            {
                result *= baseNum;
                i++;
            }
            return result;
        }
    }
}
