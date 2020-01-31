using System.Collections.Generic;

namespace Monopoly
{
    public class MoveResult
    {
        public IEnumerable<ILocation> LocationHistory { get; set; }
        public ILocation CurrentLocation { get; set; }
    }
}
