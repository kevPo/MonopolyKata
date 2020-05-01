using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;

namespace Monopoly
{
    public class MoveService : IMoveService
    {
        private readonly IBoard board;

        public MoveService(IBoard board)
        {
            this.board = board;
        }

        public MoveResult MoveToLocation(int currentLocationIndex, int locationsToMove)
        {
            var (locationHistory, newLocationIndex) = BuildLocationHistory(currentLocationIndex, locationsToMove);

            RemoveLastLocation(locationHistory);

            return new MoveResult
            {
                CurrentLocation = board.Locations.ElementAt(newLocationIndex), LocationHistory = locationHistory
            };
        }

        private (IList<ILocation>, int) BuildLocationHistory(int currentLocationIndex, int locationsToMove)
        {
            var locationHistory = new List<ILocation>();

            for (var i = 0; i < locationsToMove; i++)
            {
                currentLocationIndex = CalculationNextLocationIndex(currentLocationIndex);
                locationHistory.Add(board.Locations.ElementAt(currentLocationIndex));
            }

            return (locationHistory, currentLocationIndex);
        }

        private static void RemoveLastLocation(IList<ILocation> locationHistory)
        {
            if (locationHistory.Any())
            {
                locationHistory.RemoveAt(locationHistory.Count - 1);
            }
        }

        private int CalculationNextLocationIndex(int location)
        {
            return ++location % board.Locations.Count;
        }
    }
}
