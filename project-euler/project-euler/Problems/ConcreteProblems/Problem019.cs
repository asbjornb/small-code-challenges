namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem019 : BaseProblem, IProblem
    {
        public string Solve()
        {
            return FindSundays1().ToString();
        }

        private static int FindSundays1()
        {
            var monthLengths = new List<int>() { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            var year = 1900;
            var month = 0;
            var dayNum = 1; //Annotate 1 Jan 1900 as day 1. Sundays are 0 mod 7.
            var sundays = 0;
            while (year < 2001)
            {
                //Add a months worth of days
                dayNum += monthLengths[month];
                if (month == 1 && year % 4 == 0)
                {
                    dayNum++;
                }
                //Count if eligible
                if (dayNum % 7 == 0 && year > 1900)
                {
                    sundays++;
                }
                //Update month and year for next cycle
                if (month == 11)
                {
                    year++;
                    month = 0;
                }
                else
                {
                    month++;
                }
            }
            return sundays;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Demonstrating alternative")]
        private static int FindSundays2()
        {
            var firstDate = new DateTime(1900, 1, 1);
            var range = Enumerable.Range(0,101 * 366);
            var sundays = range.Select(x => firstDate.AddDays(x)).Count(x => x.Day == 1
                                                                        && x.DayOfWeek == DayOfWeek.Sunday
                                                                        && x.Year > 1900
                                                                        && x.Year < 2001);
            return sundays;
        }
    }
}
