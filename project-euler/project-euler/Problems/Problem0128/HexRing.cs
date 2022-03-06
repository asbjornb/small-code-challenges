namespace project_euler.Problems.Problem0128
{
    //Represents a ring of individual hexes
    internal sealed class HexRing
    {
        public int RingNumber { get; }

        public List<Hex> Ring { get; }

        private HexRing(int ringNumber, List<Hex> ring)
        {
            RingNumber = ringNumber;
            Ring = ring;
        }

        public static HexRing ConstructRing()
        {
            return new HexRing(1, new List<Hex>() { new Hex(1)});
        }

        //Implementation doesn't link the hexes in the ring together
        //Also doesn't handle cases where 
        public static HexRing ConstructRing(HexRing innerRing)
        {
            var ring = new List<Hex>();

            //First element
            var innerTop = innerRing.Ring[0];
            var i = innerRing.Ring.Last().InternalNum + 1;

            var first = new Hex(i);
            first.XDown = innerTop;
            innerTop.XUp = first;
            ring.Add(first);

            //Second element
            i++;
            var second = new Hex(i);
            second.YDown = innerTop;
            innerTop.YUp = second;
            ring.Add(second);

            //All other elements
            foreach (var hex in innerRing.Ring)
            {
                //Should refactor with direction class. Enumlike, with reverse operation. A neighbour is then a hex, direction tuple?
                if(hex.XUp is null)
                {
                    i++;
                    var newHex=new Hex(i);
                    newHex.XDown = hex;
                    hex.XUp = newHex;
                    ring.Add(newHex);
                }
                if (hex.YUp is null)
                {
                    i++;
                    var newHex = new Hex(i);
                    newHex.YDown = hex;
                    hex.YUp = newHex;
                    ring.Add(newHex);
                }
                if (hex.ZUp is null)
                {
                    i++;
                    var newHex = new Hex(i);
                    newHex.ZDown = hex;
                    hex.ZUp = newHex;
                    ring.Add(newHex);
                }
                if (hex.XDown is null)
                {
                    i++;
                    var newHex = new Hex(i);
                    newHex.XUp = hex;
                    hex.XDown = newHex;
                    ring.Add(newHex);
                }
                if (hex.YDown is null)
                {
                    i++;
                    var newHex = new Hex(i);
                    newHex.YUp = hex;
                    hex.YDown = newHex;
                    ring.Add(newHex);
                }
                if (hex.ZDown is null)
                {
                    i++;
                    var newHex = new Hex(i);
                    newHex.ZUp = hex;
                    hex.ZDown = newHex;
                    ring.Add(newHex);
                }
            }

            //Last element
            if(innerTop.ZUp is null) //Second ring only
            {
                i++;
                var last = new Hex(i);
                last.ZDown = innerTop;
                innerTop.ZUp = last;
                ring.Add(last);
            }

            return new HexRing(innerRing.RingNumber + 1, ring);
        }
    }
}
