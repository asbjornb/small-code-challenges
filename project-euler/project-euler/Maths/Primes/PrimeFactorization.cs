using System.Collections;

namespace project_euler.Maths.Primes
{
    internal class PrimeFactorization : IEnumerable<PrimeFactor>
    {
        private readonly Dictionary<int, int> primeFactors;

        public PrimeFactorization()
        {
            primeFactors = new();
        }

        private PrimeFactorization(PrimeFactorization factors)
        {
            primeFactors = new Dictionary<int, int>(factors.primeFactors); //Shallow dict clone
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

        public bool TryRemove(int prime)
        {
            if (primeFactors.ContainsKey(prime))
            {
                if (primeFactors[prime] == 1)
                {
                    return primeFactors.Remove(prime);
                }
                primeFactors[prime]--;
                return true;
            }
            return false;
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

        public PrimeFactorization Add(PrimeFactorization other)
        {
            var result = Clone();
            foreach (var factor in other.ToList())
            {
                result.AddFactor(factor);
            }
            return result;
        }

        public PrimeFactorization Clone()
        {
            return new PrimeFactorization(this);
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

        public IEnumerator<PrimeFactor> GetEnumerator()
        {
            return primeFactors.Select(factor => new PrimeFactor(factor.Key, factor.Value)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
