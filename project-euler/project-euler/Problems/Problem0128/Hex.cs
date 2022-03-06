namespace project_euler.Problems.Problem0128
{
    internal class Hex
    {
        public int InternalNum { get; }
        
        //Neighbours
        public Hex? XUp { get; set; }
        public Hex? XDown { get; set; }
        public Hex? YUp { get; set; }
        public Hex? YDown { get; set; }
        public Hex? ZUp { get; set; }
        public Hex? ZDown { get; set; }

        public Hex(int internalNum)
        {
            InternalNum = internalNum;
        }

        public List<Hex?> Neighbours => new() { XUp, XDown, YUp, YDown, ZUp, ZDown };

        public bool IsInitialized => Neighbours.All(x => x is not null);

        //Throws runtime nullpointerexception if not initialized
        public List<int> GetDiffs => Neighbours.ConvertAll(x => Math.Abs(x!.InternalNum - InternalNum));
    }
}
