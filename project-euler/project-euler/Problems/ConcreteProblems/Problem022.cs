namespace project_euler.Problems.ConcreteProblems
{
    internal class Problem022 : BaseProblem, IProblem
    {
        public string Solve()
        {
            var names = ReadFile("./Problems/ConcreteProblems/Problem022/p022_names.txt");
            return SumNameScores(names).ToString();
        }

        private static IEnumerable<string> ReadFile(string path)
        {
            string text = File.ReadAllText(path);
            return text.Replace(@"""", "").Split(",");
        }

        private static int SumNameScores(IEnumerable<string> input)
        {
            var sorted = input.OrderBy(x => x);
            return sorted.Select((name, index) => GetScore(name)*(index+1)).Sum();
        }

        private static int GetScore(string name)
        {
            return name.Select(x => (x - 'A') + 1).Sum();
        }
    }
}
