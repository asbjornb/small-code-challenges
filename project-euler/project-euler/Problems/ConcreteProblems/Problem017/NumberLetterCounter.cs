namespace project_euler.Problems.ConcreteProblems.Problem017Model
{
    internal class NumberLetterCounter
    {
        public int Convert(int num)
        {
            if (num >= 1 && num <= 20)
            {
                return LetterCounts[num];
            }
            if (num >= 21 && num < 100)
            {
                var tens = (num / 10) * 10;
                return LetterCounts[tens] + LetterCounts[num % 10];
            }
            if (num >= 100 && num < 1000)
            {
                var hundreds = (num / 100);
                var rest = num % 100;
                if (rest == 0)
                {
                    return LetterCounts[hundreds] + "hundred".Length;
                }
                return LetterCounts[hundreds] + "hundred".Length
                    + "and".Length
                    + Convert(rest);
            }
            if (num == 1000)
            {
                return "Onethousand".Length;
            }
            return 0;
        }

        private static readonly Dictionary<int, int> LetterCounts = new()
        {
            { 0, 0 },
            { 1, "one".Length },
            { 2, "two".Length },
            { 3, "three".Length },
            { 4, "four".Length },
            { 5, "five".Length },
            { 6, "six".Length },
            { 7, "seven".Length },
            { 8, "eight".Length },
            { 9, "nine".Length },
            { 10, "ten".Length },
            { 11, "eleven".Length },
            { 12, "twelve".Length },
            { 13, "thirteen".Length },
            { 14, "fourteen".Length },
            { 15, "fifteen".Length },
            { 16, "sixteen".Length },
            { 17, "seventeen".Length },
            { 18, "eighteen".Length },
            { 19, "nineteen".Length },
            { 20, "twenty".Length },
            { 30, "thirty".Length },
            { 40, "forty".Length },
            { 50, "fifty".Length },
            { 60, "sixty".Length },
            { 70, "seventy".Length },
            { 80, "eighty".Length },
            { 90, "ninety".Length },
        };
    }
}
