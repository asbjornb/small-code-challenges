namespace project_euler.Problems.ConcreteProblems.Problem011Model
{
    internal class Grid
    {
        private readonly List<CoordinateWithInt> grid = new();
        private readonly int maxX;
        private readonly int maxY;

        public Grid(int[][] grid)
        {
            for (int i = 0; i < grid[0].Length; i++)
            {
                for (int j = 0; j < grid.Length; j++)
                {
                    this.grid.Add(new CoordinateWithInt(i, j, grid[j][i]));
                }
            }
            maxX = grid.Length - 1;
            maxY = grid[0].Length - 1;
        }

        public IEnumerable<int[]> GetRows()
        {
            for (int i = 0; i <= maxY; i++)
            {
                yield return grid.Where(c => c.Y == i).Select(c => c.Value).ToArray();
            }
        }

        public IEnumerable<int[]> GetCols()
        {
            for (int i = 0; i <= maxX; i++)
            {
                yield return grid.Where(c => c.X == i).Select(c => c.Value).ToArray();
            }
        }

        public IEnumerable<int[]> GetLeftDiagonals()
        {
            for (int i = -maxY; i <= maxX; i++)
            {
                yield return grid.Where(c => c.X - c.Y == i).Select(c => c.Value).ToArray();
            }
        }

        public IEnumerable<int[]> GetRightDiagonals()
        {
            for (int i = -maxY; i <= maxX; i++)
            {
                yield return grid.Where(c => c.Y == -c.X + (maxY + i)).Select(c => c.Value).ToArray();
            }
        }

        public IEnumerable<int[]> GetAllLines()
        {
            return GetRightDiagonals().Concat(GetLeftDiagonals()).Concat(GetRows()).Concat(GetCols());
        }
    }
}
