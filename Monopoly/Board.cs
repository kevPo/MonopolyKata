using System.Collections.Generic;
using System.Linq;
using Monopoly.Actions;
using Monopoly.Locations;

namespace Monopoly
{
    public class Board
    {
        private const int NumberOfLocations = 40;

        public IEnumerable<ILocation> Locations { get; private set; }

        public Board()
        {
            Locations = PopulateLocations();
        }

        private IEnumerable<ILocation> PopulateLocations()
        {
            return new ILocation[]
            {
                new Location(LocationConstants.GoLocationName, LocationConstants.GoLocationIndex, new PayoutAction(MonopolyConstants.GoPayoutAmount), new PayoutAction(MonopolyConstants.GoPayoutAmount)),
                new NullLocation("Empty", 1),
                new NullLocation("Empty", 2),
                new NullLocation("Empty", 3),
                new NullLocation("Empty", 4),
                new NullLocation("Empty", 5),
                new NullLocation("Empty", 6),
                new NullLocation("Empty", 7),
                new NullLocation("Empty", 8),
                new NullLocation("Empty", 9),
                new NullLocation("Empty", 10),
                new NullLocation("Empty", 11),
                new NullLocation("Empty", 12),
                new NullLocation("Empty", 13),
                new NullLocation("Empty", 14),
                new NullLocation("Empty", 15),
                new NullLocation("Empty", 16),
                new NullLocation("Empty", 17),
                new NullLocation("Empty", 18),
                new NullLocation("Empty", 19),
                new NullLocation("Empty", 20),
                new NullLocation("Empty", 21),
                new NullLocation("Empty", 22),
                new NullLocation("Empty", 23),
                new NullLocation("Empty", 24),
                new NullLocation("Empty", 25),
                new NullLocation("Empty", 26),
                new NullLocation("Empty", 27),
                new NullLocation("Empty", 28),
                new NullLocation("Empty", 29),
                new Location(LocationConstants.GoToJailLocationName, LocationConstants.GoToJailLocationIndex, new NullAction(), new RelocateAction(LocationConstants.JustVisitingLocationIndex)),
                new NullLocation("Empty", 31),
                new NullLocation("Empty", 32),
                new NullLocation("Empty", 33),
                new NullLocation("Empty", 34),
                new NullLocation("Empty", 35),
                new NullLocation("Empty", 36),
                new NullLocation("Empty", 37),
                new NullLocation("Empty", 38),
                new NullLocation("Empty", 39)
            };
        }

        public MoveResult MoveToLocation(int currentLocationIndex, int locationsToMove)
        {
            var (locationHistory, newLocationIndex) = BuildLocationHistory(currentLocationIndex, locationsToMove);

            RemoveLastLocation(locationHistory);

            return new MoveResult { CurrentLocation = Locations.ElementAt(newLocationIndex), LocationHistory = locationHistory };
        }

        private (List<ILocation>, int) BuildLocationHistory(int currentLocationIndex, int locationsToMove)
        {
            var locationHistory = new List<ILocation>();

            for (var i = 0; i < locationsToMove; i++)
            {
                currentLocationIndex = CalculationNextLocationIndex(currentLocationIndex);
                locationHistory.Add(Locations.ElementAt(currentLocationIndex));
            }

            return (locationHistory, currentLocationIndex);
        }

        private static void RemoveLastLocation(List<ILocation> locationHistory)
        {
            if (locationHistory.Any())
            {
                locationHistory.RemoveAt(locationHistory.Count - 1);
            }
        }

        private int CalculationNextLocationIndex(int location)
        {
            return ++location % NumberOfLocations;
        }
    }
}
