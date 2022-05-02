namespace project_euler.Util
{
    internal static class Digits
    {
        public static List<int> GetDigits(int num)
        {
            var result = new List<int>();
            while (num > 0)
            {
                var digit = num % 10;
                result.Add(digit);
                num /= 10;
            }
            result.Reverse();
            return result;
        }

        public static int ToNum(IEnumerable<int> asArray)
        {
            var i = 1;
            var result = 0;
            foreach (var digit in asArray.Reverse())
            {
                result += digit * i;
                i *= 10;
            }
            return result;
        }
    }
}
