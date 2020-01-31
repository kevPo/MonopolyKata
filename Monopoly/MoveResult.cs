using System.Collections.Generic;
using Monopoly.Locations;

namespace Monopoly
{
    public class MoveResult
    {
        public IEnumerable<ILocation> LocationHistory { get; set; }
        public ILocation CurrentLocation { get; set; }
    }
}
