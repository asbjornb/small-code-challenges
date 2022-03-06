namespace project_euler.Problems
{
    internal interface IProblem
    {
        string Name { get; }
        string Description { get; }

        string Solve();
    }
}
