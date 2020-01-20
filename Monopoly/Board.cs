using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Board
    {
        public const int Go = 0;
        private const int NumberOfLocations = 40;

        public IEnumerable<int> Locations { get; private set; }

        public Board()
        {
            Locations = Enumerable.Range(0, NumberOfLocations);
        }

        public MoveResult MoveToLocation(int currentLocation, int locationsToMove)
        {
            var locationHistory = new List<int>();

            for (var i = 0; i < locationsToMove; i++)
            {
                currentLocation = CalculateNextLocation(currentLocation);
                locationHistory.Add(currentLocation);
            }

            return new MoveResult { CurrentLocation = currentLocation, LocationHistory = locationHistory };
        }

        private int CalculateNextLocation(int location)
        {
            return ++location % NumberOfLocations;
        }
    }
}
