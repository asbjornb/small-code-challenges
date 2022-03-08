namespace project_euler.Problems.Problem0128
{
    internal class Hex
    {
        public int InternalNum { get; }

        //Neighbours. Ordered top and then counterclockwise
        public Hex? XUp { get; set; }
        public Hex? YUp { get; set; }
        public Hex? ZUp { get; set; }
        public Hex? XDown { get; set; }
        public Hex? YDown { get; set; }
        public Hex? ZDown { get; set; }

        public Hex(int internalNum)
        {
            InternalNum = internalNum;
        }

        public List<Hex?> SortedNeighbours => new() { XUp, YUp, ZUp, XDown, YDown, ZDown };

        public bool IsInitialized => SortedNeighbours.All(x => x is not null);

        //Throws runtime nullpointerexception if not initialized
        public List<int> GetDiffs => SortedNeighbours.ConvertAll(x => Math.Abs(x!.InternalNum - InternalNum));
    }
}
