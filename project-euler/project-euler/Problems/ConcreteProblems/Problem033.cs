namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem033 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindDigitCancellingFractions().ToString();
        }

        private static int FindDigitCancellingFractions()
        {
            var fractions = new List<(int numerator,int denominator)>();
            for (int x = 1; x < 10; x++)
            {
                for (int y = 1; y < 10; y++)
                {
                    for (int z = 1; z < 10; z++)
                    {
                        //We look for fractions "xz"/"yz" where x/y="xz"/"yz" and z!=0 or rewritten x*"yz"=y*"xz"
                        var xz = (x * 10) + z;
                        var yz = (y * 10) + z;
                        var zx = (z * 10) + x;
                        var zy = (z * 10) + y;
                        if (x * yz == y * xz && xz<yz)
                        {
                            fractions.Add((xz, yz));
                        }
                        //Now fractions "zx"/"zy"=x/y
                        if (x * zy == y * zx && zx < zy)
                        {
                            fractions.Add((zx, zy));
                        }
                        //Now fractions "xz"/"zy"=x/y
                        if (x * zy == y * xz && xz < zy)
                        {
                            fractions.Add((xz, zy));
                        }
                        //Now fractions "zx"/"yz"=x/y
                        if (x * yz == y * zx && zx < yz)
                        {
                            fractions.Add((zx, yz));
                        }
                    }
                }
            }
            var product = (1,1);
            foreach (var (numerator, denominator) in fractions)
            {
                product.Item1 *= numerator;
                product.Item2 *= denominator;
            }
            for (int i = 2; i <= product.Item1; i++)
            {
                while (product.Item1 % i == 0 && product.Item2 % i == 0)
                {
                    product.Item1 /= i;
                    product.Item2 /= i;
                }
            }
            return product.Item2;
        }
    }
}
