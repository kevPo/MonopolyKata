using System.Collections.Generic;

namespace Monopoly
{
    public class MoveResult
    {
        public IEnumerable<int> LocationHistory { get; set; }
        public int CurrentLocation { get; set; }
    }
}
