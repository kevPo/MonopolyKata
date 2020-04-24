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

            Locations = new[]
            {
                CreateLocation(LocationConstants.GoIndex, new PayoutAction(MonopolyConstants.GoPayoutAmount), new PayoutAction(MonopolyConstants.GoPayoutAmount)),
                realEstateFactory.Create(LocationConstants.MediterraneanAveIndex, LocationConstants.PurplePropertyGroup, LocationConstants.MediterraneanAveCost, LocationConstants.MediterraneanAveRent),
                nullLocationFactory.Create(2),
                realEstateFactory.Create(LocationConstants.BalticAveIndex, LocationConstants.PurplePropertyGroup, LocationConstants.BalticAveCost, LocationConstants.BalticAveRent),
                CreateLocation(LocationConstants.IncomeTaxIndex, new IncomeTaxAction(MonopolyConstants.IncomeTaxRate, MonopolyConstants.IncomeTaxMaximumAmount)),
                railroadFactory.Create(LocationConstants.ReadingRailroadIndex),
                realEstateFactory.Create(LocationConstants.OrientalAveIndex, LocationConstants.LightBluePropertyGroup, LocationConstants.OrientalAveCost, LocationConstants.OrientalAveRent),
                nullLocationFactory.Create(7),
                realEstateFactory.Create(LocationConstants.VermontAveIndex, LocationConstants.LightBluePropertyGroup, LocationConstants.VermontAveCost, LocationConstants.VermontAveRent),
                realEstateFactory.Create(LocationConstants.ConnecticutAveIndex, LocationConstants.LightBluePropertyGroup, LocationConstants.ConnecticutAveCost, LocationConstants.ConnecticutAveRent),
                nullLocationFactory.Create(10),
                realEstateFactory.Create(LocationConstants.StCharlesPlaceIndex, LocationConstants.VioletPropertyGroup, LocationConstants.StCharlesPlaceCost, LocationConstants.StCharlesPlaceRent),
                utilityFactory.Create(LocationConstants.ElectricCompanyIndex),
                realEstateFactory.Create(LocationConstants.StatesAveIndex, LocationConstants.VioletPropertyGroup, LocationConstants.StatesAveCost, LocationConstants.StatesAveRent),
                realEstateFactory.Create(LocationConstants.VirginiaAveIndex, LocationConstants.VioletPropertyGroup, LocationConstants.VirginiaAveCost, LocationConstants.VirginiaAveRent),
                railroadFactory.Create(LocationConstants.PennsylvaniaRailroadIndex),
                realEstateFactory.Create(LocationConstants.StJamesPlaceIndex, LocationConstants.OrangePropertyGroup, LocationConstants.StJamesPlaceCost, LocationConstants.StJamesPlaceRent),
                nullLocationFactory.Create(17),
                realEstateFactory.Create(LocationConstants.TennesseeAveIndex, LocationConstants.OrangePropertyGroup, LocationConstants.TennesseeAveCost, LocationConstants.TennesseeAveRent),
                realEstateFactory.Create(LocationConstants.NewYorkAveIndex, LocationConstants.OrangePropertyGroup, LocationConstants.NewYorkAveCost, LocationConstants.NewYorkAveRent),
                nullLocationFactory.Create(20),
                realEstateFactory.Create(LocationConstants.KentuckyAveIndex, LocationConstants.RedPropertyGroup, LocationConstants.KentuckyAveCost, LocationConstants.KentuckyAveRent),
                nullLocationFactory.Create(22),
                realEstateFactory.Create(LocationConstants.IndianaAveIndex, LocationConstants.RedPropertyGroup, LocationConstants.IndianaAveCost, LocationConstants.IndianaAveRent),
                realEstateFactory.Create(LocationConstants.IllinoisAveIndex, LocationConstants.RedPropertyGroup, LocationConstants.IllinoisAveCost, LocationConstants.IllinoisAveRent),
                railroadFactory.Create(LocationConstants.BAndORailroadIndex),
                realEstateFactory.Create(LocationConstants.AtlanticAveIndex, LocationConstants.YellowPropertyGroup, LocationConstants.AtlanticAveCost, LocationConstants.AtlanticAveRent),
                realEstateFactory.Create(LocationConstants.VentnorAveIndex, LocationConstants.YellowPropertyGroup, LocationConstants.VentnorAveCost, LocationConstants.VentnorAveRent),
                utilityFactory.Create(LocationConstants.WaterWorksIndex),
                realEstateFactory.Create(LocationConstants.MarvinGardensIndex, LocationConstants.YellowPropertyGroup, LocationConstants.MarvinGardensCost, LocationConstants.MarvinGardensRent),
                CreateLocation(LocationConstants.GoToJailIndex, new GoToJailAction()),
                realEstateFactory.Create(LocationConstants.PacificAveIndex, LocationConstants.DarkGreenPropertyGroup, LocationConstants.PacificAveCost, LocationConstants.PacificAveRent),
                realEstateFactory.Create(LocationConstants.NorthCarolinaAveIndex, LocationConstants.DarkGreenPropertyGroup, LocationConstants.NorthCarolinaAveCost, LocationConstants.NorthCarolinaAveRent),
                nullLocationFactory.Create(33),
                realEstateFactory.Create(LocationConstants.PennsylvaniaAveIndex, LocationConstants.DarkGreenPropertyGroup, LocationConstants.PennsylvaniaAveCost, LocationConstants.PennsylvaniaAveRent),
                railroadFactory.Create(LocationConstants.ShortLineRailroadIndex),
                nullLocationFactory.Create(36),
                realEstateFactory.Create(LocationConstants.ParkPlaceIndex, LocationConstants.DarkBluePropertyGroup, LocationConstants.ParkPlaceCost, LocationConstants.ParkPlaceRent),
                CreateLocation(LocationConstants.LuxuryTaxIndex, new LuxuryTaxAction(MonopolyConstants.LuxuryTaxAmount)),
                realEstateFactory.Create(LocationConstants.BoardwalkIndex, LocationConstants.DarkBluePropertyGroup, LocationConstants.BoardwalkCost, LocationConstants.BoardwalkRent)
            };
        }

        private static ILocation CreateLocation(int locationIndex, IAction landingAction)
        {
            return new Location(locationIndex, landingAction, new NullAction());
        }

        private static ILocation CreateLocation(int locationIndex, IAction landingAction, IAction passingAction)
        {
            return new Location(locationIndex, landingAction, passingAction);
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
                .Where(p => p.PropertyGroup.Value ==
                            LocationConstants.RailroadGroup.Value) // could be done with struct operator
                .Count(p => p.Owner == player);
        }

        public int NumberOfUtilitiesOwned()
        {
            return Locations.OfType<IProperty>()
                .Where(p => p.PropertyGroup.Value ==
                            LocationConstants.UtilityGroup.Value) // could be done with struct operator
                .Count(p => p.Owner != null);
        }
    }
}
