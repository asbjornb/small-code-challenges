using project_euler.Maths.Sets;

namespace project_euler.Problems.ConcreteProblems
{
    //See also 105, 106 for similar problems
    internal class Problem103 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindMinimalSSS();
        }

        private static string FindMinimalSSS()
        {
            //Let S7 denote the optimal SSS og size 7. The given algorithm for near optimal sets gives us an upper bound for Sum(S7) of:
            var upperBound = new List<int> { 20, 31, 38, 39, 40, 42, 45 }.Sum(); //Is valid SSS of size 7. =255
            //Observe that any subset of a SSS is itself an SSS (otherwise the subsets violating the smaller one would also be subsets
            //and thus violating the larger one.
            //So if we annotate the elements of S7 as e1, e2, ..., e7 in order from smallest to largest. Then {e1,...e6} is again an SSS.
            //Then Sum({e1,...e6})>=Sum(S6) the optimal subset of size 6 which is given as { 11, 18, 19, 20, 22, 25 } in the problem statement.
            //So further 7*e7>=e7+(e6+1)+(e5+2)+...+(e1+6)>=e7+Sum({e1,...e6})+21>=e7+S6+21=e7+115+21=e7+136 => e7>=136/6=23
            //And as seen Sum(S7)>=Sum({e1,...e6})+e7>=115+23=138.

            //var lowerBound = new List<int>{ 11, 18, 19, 20, 22, 25 }.Sum()+23; //S6 example+min(e7).

            //By property 2 of SSS's e1+e2>e_n for n 3,4,5,6,7 so since 138<=Sum(S7)=(e1+e2)+e3+e4+e5+e6+e7<=(e1+e2)+(e1+e2+5)...(e1+e2+1)<=6*(e1+e2)+15 then
            //e1+e2>=(138+15)/6=26 so e2>=14.
            //Conversely e7 is less than any 2 other elements so 4*e7<(e7)+(e5+e6)+(e3+e4+4)+(e1+e2+8)=S7+12<=255+12=267 so e7<=267/4=66

            //Lets find the set {e2,...,e7} which is again SSS:
            var minExample = new List<int> { 20, 31, 38, 39, 40, 42, 45 };
            var minSum = minExample.Sum();
            for (int e2 = 14; e2 <= 66 - 5; e2++) //bounded by 14 and e2<e3<e4...<e7<=66
            {
                var elementBound = (2 * e2) - 1;//Prop 2 says e_n<e1+e2<=2*e2-1 so this is an upper bound for any element
                                                //Used as standin for e1+e2 in many inequalities too since e1+e2<=2*e2-1
                for (int e3 = e2 + 1; e3 <= Math.Min(66 - 4, elementBound); e3++)
                {
                    for (int e4 = e3 + 1; e4 <= Math.Min(66 - 3, elementBound); e4++)
                    {
                        if (e3 + (5 * e4) + 7 > upperBound) //e1+e2>=e4+1, e5>=e4+1 etc.
                        { break; }
                        var sss = new SpecialSumSet();
                        sss.Add(e2);
                        sss.Add(e3);
                        if (!sss.Add(e4))
                        {
                            continue;
                        }
                        for (int e5 = e4 + 1; e5 <= Math.Min(66 - 2, elementBound); e5++)
                        {
                            if (e3 + e4 + (4 * e5) + 4 > upperBound
                                || e5 + e4 >= elementBound + e3) { break; } //Prop 2 says: e4+e5<e1+e2+e3<=2*e2-1+e3
                            var sss5 = sss.Clone();
                            if (!sss5.Add(e5)) { continue; }
                            for (int e6 = e5 + 1; e6 <= Math.Min(66 - 1, elementBound); e6++)
                            {
                                if (e3 + e4 + e5 + (3 * e6) + 2 > upperBound
                                    || e6 + e5 >= elementBound + e3) { break; }
                                var sss6 = sss5.Clone();
                                if (!sss6.Add(e6)) { continue; }
                                for (int e7 = e6 + 1; e6 <= Math.Min(66, elementBound); e7++)
                                {
                                    if (e3 + e4 + e5 + e6 + (2 * e7) + 1 > upperBound
                                        || e6 + e7 >= elementBound + e3
                                        || e5 + e6 + e7 >= elementBound + e3 + e4) { break; }
                                    var sss7 = sss6.Clone();
                                    if (!sss7.Add(e7)) { continue; }
                                    for (int e1 = e2 - 1; e1 + e2 > e7; e1--)
                                    {
                                        var sss1 = sss7.Clone();
                                        if (e1 + e2 + e3 + e4 + e5 + e6 + e7 <= upperBound
                                            && sss1.Add(e1)
                                            && e1 + e2 + e3 + e4 + e5 + e6 + e7 <= minSum) //Should be < but <= allows another example
                                        {
                                            minSum = e1 + e2 + e3 + e4 + e5 + e6 + e7;
                                            minExample = new List<int> { e1, e2, e3, e4, e5, e6, e7 };
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return minExample[0].ToString() + minExample[1].ToString() + minExample[2].ToString() + minExample[3].ToString() + minExample[4].ToString()
                                                + minExample[5].ToString() + minExample[6].ToString();
        }
    }
}
