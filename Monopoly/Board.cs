using System.Collections.Generic;
using System.Linq;
using Monopoly.Actions;
using Monopoly.Locations;

namespace Monopoly
{
    public class Board : IBoard
    {
        private const int NumberOfLocations = 40;

        public IList<ILocation> Locations { get; }

        public IDictionary<int, ILocation> LocationDictionary => Locations.ToDictionary(l => l.LocationIndex);

        public IDictionary<int, IProperty> PropertyDictionary => Locations.OfType<IProperty>().ToDictionary(l => l.LocationIndex);

        public Board(IDice dice)
        {
            var utilityFactory = new UtilityFactory(this, dice);
            var railroadFactory = new RailroadFactory(this);
            var realEstateFactory = new RealEstateFactory(this);
            var nullLocationFactory = new NullLocationFactory();
            var genericLocationFactory = new GenericLocationFactory();

            Locations = new[]
            {
                genericLocationFactory.Create(LocationConstants.GoIndex, new PayoutAction(MonopolyConstants.GoPayoutAmount), new PayoutAction(MonopolyConstants.GoPayoutAmount)),
                realEstateFactory.Create(LocationConstants.MediterraneanAveIndex),
                nullLocationFactory.Create(2),
                realEstateFactory.Create(LocationConstants.BalticAveIndex),
                genericLocationFactory.Create(LocationConstants.IncomeTaxIndex, new IncomeTaxAction(MonopolyConstants.IncomeTaxRate, MonopolyConstants.IncomeTaxMaximumAmount)),
                railroadFactory.Create(LocationConstants.ReadingRailroadIndex),
                realEstateFactory.Create(LocationConstants.OrientalAveIndex),
                nullLocationFactory.Create(7),
                realEstateFactory.Create(LocationConstants.VermontAveIndex),
                realEstateFactory.Create(LocationConstants.ConnecticutAveIndex),
                nullLocationFactory.Create(10),
                realEstateFactory.Create(LocationConstants.StCharlesPlaceIndex),
                utilityFactory.Create(LocationConstants.ElectricCompanyIndex),
                realEstateFactory.Create(LocationConstants.StatesAveIndex),
                realEstateFactory.Create(LocationConstants.VirginiaAveIndex),
                railroadFactory.Create(LocationConstants.PennsylvaniaRailroadIndex),
                realEstateFactory.Create(LocationConstants.StJamesPlaceIndex),
                nullLocationFactory.Create(17),
                realEstateFactory.Create(LocationConstants.TennesseeAveIndex),
                realEstateFactory.Create(LocationConstants.NewYorkAveIndex),
                nullLocationFactory.Create(20),
                realEstateFactory.Create(LocationConstants.KentuckyAveIndex),
                nullLocationFactory.Create(22),
                realEstateFactory.Create(LocationConstants.IndianaAveIndex),
                realEstateFactory.Create(LocationConstants.IllinoisAveIndex),
                railroadFactory.Create(LocationConstants.BAndORailroadIndex),
                realEstateFactory.Create(LocationConstants.AtlanticAveIndex),
                realEstateFactory.Create(LocationConstants.VentnorAveIndex),
                utilityFactory.Create(LocationConstants.WaterWorksIndex),
                realEstateFactory.Create(LocationConstants.MarvinGardensIndex),
                genericLocationFactory.Create(LocationConstants.GoToJailIndex, new GoToJailAction()),
                realEstateFactory.Create(LocationConstants.PacificAveIndex),
                realEstateFactory.Create(LocationConstants.NorthCarolinaAveIndex),
                nullLocationFactory.Create(33),
                realEstateFactory.Create(LocationConstants.PennsylvaniaAveIndex),
                railroadFactory.Create(LocationConstants.ShortLineRailroadIndex),
                nullLocationFactory.Create(36),
                realEstateFactory.Create(LocationConstants.ParkPlaceIndex),
                genericLocationFactory.Create(LocationConstants.LuxuryTaxIndex, new LuxuryTaxAction(MonopolyConstants.LuxuryTaxAmount)),
                realEstateFactory.Create(LocationConstants.BoardwalkIndex)
            };
        }

        public MoveResult MoveToLocation(int currentLocationIndex, int locationsToMove)
        {
            var (locationHistory, newLocationIndex) = BuildLocationHistory(currentLocationIndex, locationsToMove);

            RemoveLastLocation(locationHistory);

            return new MoveResult
            {
                CurrentLocation = Locations.ElementAt(newLocationIndex), LocationHistory = locationHistory
            };
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

        public bool PlayerOwnsPropertyGroup(IPlayer player, PropertyGroup propertyGroup)
        {
            return Locations.OfType<IProperty>()
                .Where(p => p.PropertyGroup.Value == propertyGroup.Value) // could be done with struct operator
                .All(p => p.Owner == player);
        }

        public int NumberOfRailRoadsOwnedByPlayer(IPlayer player)
        {
            return Locations.OfType<IProperty>()
                .Where(p => p.PropertyGroup.Value == LocationConstants.RailroadGroup.Value) // could be done with struct operator
                .Count(p => p.Owner == player);
        }

        public int NumberOfUtilitiesOwned()
        {
            return Locations.OfType<IProperty>()
                .Where(p => p.PropertyGroup.Value == LocationConstants.UtilityGroup.Value) // could be done with struct operator
                .Count(p => p.Owner != null);
        }
    }
}
