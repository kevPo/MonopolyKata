using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Board
    {
        private const int NumberOfLocations = 40;

        public Board()
        {
            Locations = Enumerable.Range(0, NumberOfLocations);
        }

        public IEnumerable<int> Locations { get; private set; }

        public int CalculateNewLocation(int currentLocation, int locationsToMove)
        {
            return (currentLocation + locationsToMove) % NumberOfLocations;
        }
    }
}
