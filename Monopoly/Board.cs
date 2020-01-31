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
                new Location(LocationConstants.GoLocationIndex, new PayoutAction(MonopolyConstants.GoPayoutAmount), new PayoutAction(MonopolyConstants.GoPayoutAmount)),
                new NullLocation(1),
                new NullLocation(2),
                new NullLocation(3),
                new Location(LocationConstants.IncomeTaxLocationIndex, new NullAction(), new IncomeTaxAction(MonopolyConstants.IncomeTaxRate, MonopolyConstants.IncomeTaxMaximumAmount)),
                new NullLocation(5),
                new NullLocation(6),
                new NullLocation(7),
                new NullLocation(8),
                new NullLocation(9),
                new NullLocation(10),
                new NullLocation(11),
                new NullLocation(12),
                new NullLocation(13),
                new NullLocation(14),
                new NullLocation(15),
                new NullLocation(16),
                new NullLocation(17),
                new NullLocation(18),
                new NullLocation(19),
                new NullLocation(20),
                new NullLocation(21),
                new NullLocation(22),
                new NullLocation(23),
                new NullLocation(24),
                new NullLocation(25),
                new NullLocation(26),
                new NullLocation(27),
                new NullLocation(28),
                new NullLocation(29),
                new Location(LocationConstants.GoToJailLocationIndex, new NullAction(), new RelocateAction(LocationConstants.JustVisitingLocationIndex)),
                new NullLocation(31),
                new NullLocation(32),
                new NullLocation(33),
                new NullLocation(34),
                new NullLocation(35),
                new NullLocation(36),
                new NullLocation(37),
                new NullLocation(38),
                new NullLocation(39)
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
