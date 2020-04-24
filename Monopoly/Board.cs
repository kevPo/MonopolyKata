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

        public IDictionary<int, IProperty> PropertyDictionary =>
            Locations.OfType<IProperty>().ToDictionary(l => l.LocationIndex);

        public Board(IDice dice)
        {
            Locations = new ILocation[]
            {
                CreateLocation(LocationConstants.GoIndex, new PayoutAction(MonopolyConstants.GoPayoutAmount), new PayoutAction(MonopolyConstants.GoPayoutAmount)),
                CreateRealEstate(LocationConstants.MediterraneanAveIndex, LocationConstants.PurplePropertyGroup, LocationConstants.MediterraneanAveCost, LocationConstants.MediterraneanAveRent),
                CreateNullLocation(2),
                CreateRealEstate(LocationConstants.BalticAveIndex, LocationConstants.PurplePropertyGroup, LocationConstants.BalticAveCost, LocationConstants.BalticAveRent),
                CreateLocation(LocationConstants.IncomeTaxIndex, landingAction: new IncomeTaxAction(MonopolyConstants.IncomeTaxRate, MonopolyConstants.IncomeTaxMaximumAmount)),
                CreateRailroad(LocationConstants.ReadingRailroadIndex, LocationConstants.RailroadGroup, LocationConstants.RailroadCost),
                CreateRealEstate(LocationConstants.OrientalAveIndex, LocationConstants.LightBluePropertyGroup, LocationConstants.OrientalAveCost, LocationConstants.OrientalAveRent),
                CreateNullLocation(7),
                CreateRealEstate(LocationConstants.VermontAveIndex, LocationConstants.LightBluePropertyGroup, LocationConstants.VermontAveCost, LocationConstants.VermontAveRent),
                CreateRealEstate(LocationConstants.ConnecticutAveIndex, LocationConstants.LightBluePropertyGroup, LocationConstants.ConnecticutAveCost, LocationConstants.ConnecticutAveRent),
                CreateNullLocation(10),
                CreateRealEstate(LocationConstants.StCharlesPlaceIndex, LocationConstants.VioletPropertyGroup, LocationConstants.StCharlesPlaceCost, LocationConstants.StCharlesPlaceRent),
                CreateUtility(LocationConstants.ElectricCompanyIndex, LocationConstants.UtilityGroup, LocationConstants.UtilityCost, dice),
                CreateRealEstate(LocationConstants.StatesAveIndex, LocationConstants.VioletPropertyGroup, LocationConstants.StatesAveCost, LocationConstants.StatesAveRent),
                CreateRealEstate(LocationConstants.VirginiaAveIndex, LocationConstants.VioletPropertyGroup, LocationConstants.VirginiaAveCost, LocationConstants.VirginiaAveRent),
                CreateRailroad(LocationConstants.PennsylvaniaRailroadIndex, LocationConstants.RailroadGroup, LocationConstants.RailroadCost),
                CreateRealEstate(LocationConstants.StJamesPlaceIndex, LocationConstants.OrangePropertyGroup, LocationConstants.StJamesPlaceCost, LocationConstants.StJamesPlaceRent),
                CreateNullLocation(17), 
                CreateRealEstate(LocationConstants.TennesseeAveIndex, LocationConstants.OrangePropertyGroup, LocationConstants.TennesseeAveCost, LocationConstants.TennesseeAveRent),
                CreateRealEstate(LocationConstants.NewYorkAveIndex, LocationConstants.OrangePropertyGroup, LocationConstants.NewYorkAveCost, LocationConstants.NewYorkAveRent),
                CreateNullLocation(20), 
                CreateRealEstate(LocationConstants.KentuckyAveIndex, LocationConstants.RedPropertyGroup, LocationConstants.KentuckyAveCost, LocationConstants.KentuckyAveRent),
                CreateNullLocation(22), 
                CreateRealEstate(LocationConstants.IndianaAveIndex, LocationConstants.RedPropertyGroup, LocationConstants.IndianaAveCost, LocationConstants.IndianaAveRent),
                CreateRealEstate(LocationConstants.IllinoisAveIndex, LocationConstants.RedPropertyGroup, LocationConstants.IllinoisAveCost, LocationConstants.IllinoisAveRent),
                CreateRailroad(LocationConstants.BAndORailroadIndex, LocationConstants.RailroadGroup, LocationConstants.RailroadCost),
                CreateRealEstate(LocationConstants.AtlanticAveIndex, LocationConstants.YellowPropertyGroup, LocationConstants.AtlanticAveCost, LocationConstants.AtlanticAveRent),
                CreateRealEstate(LocationConstants.VentnorAveIndex, LocationConstants.YellowPropertyGroup, LocationConstants.VentnorAveCost, LocationConstants.VentnorAveRent),
                CreateUtility(LocationConstants.WaterWorksIndex, LocationConstants.UtilityGroup, LocationConstants.UtilityCost, dice),
                CreateRealEstate(LocationConstants.MarvinGardensIndex, LocationConstants.YellowPropertyGroup, LocationConstants.MarvinGardensCost, LocationConstants.MarvinGardensRent),
                CreateLocation(LocationConstants.GoToJailIndex, landingAction: new GoToJailAction()),
                CreateRealEstate( LocationConstants.PacificAveIndex, LocationConstants.DarkGreenPropertyGroup, LocationConstants.PacificAveCost, LocationConstants.PacificAveRent),
                CreateRealEstate(LocationConstants.NorthCarolinaAveIndex, LocationConstants.DarkGreenPropertyGroup, LocationConstants.NorthCarolinaAveCost, LocationConstants.NorthCarolinaAveRent),
                CreateNullLocation(33), 
                CreateRealEstate(LocationConstants.PennsylvaniaAveIndex, LocationConstants.DarkGreenPropertyGroup, LocationConstants.PennsylvaniaAveCost, LocationConstants.PennsylvaniaAveRent),
                CreateRailroad(LocationConstants.ShortLineRailroadIndex, LocationConstants.RailroadGroup, LocationConstants.RailroadCost),
                CreateNullLocation(36), 
                CreateRealEstate(LocationConstants.ParkPlaceIndex, LocationConstants.DarkBluePropertyGroup, LocationConstants.ParkPlaceCost, LocationConstants.ParkPlaceRent),
                CreateLocation(LocationConstants.LuxuryTaxIndex, landingAction: new LuxuryTaxAction(MonopolyConstants.LuxuryTaxAmount)),
                CreateRealEstate(LocationConstants.BoardwalkIndex, LocationConstants.DarkBluePropertyGroup, LocationConstants.BoardwalkCost, LocationConstants.BoardwalkRent),
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

        private static ILocation CreateNullLocation(int locationIndex)
        {
            return new NullLocation(locationIndex);
        }

        private ILocation CreateRealEstate(int locationIndex, PropertyGroup propertyGroup, Money cost, Money rent)
        {
            var realEstateRentAction = new RealEstateRentAction(this);
            return new Property(locationIndex, propertyGroup, realEstateRentAction, cost, rent);
        }

        private ILocation CreateRailroad(int locationIndex, PropertyGroup propertyGroup, Money cost)
        {
            var railroadRentAction = new RailroadRentAction(this);
            return new Property(locationIndex, propertyGroup, railroadRentAction, cost);
        }

        private ILocation CreateUtility(int locationIndex, PropertyGroup propertyGroup, Money cost, IDice dice)
        {
            var utilityRentAction = new UtilityRentAction(this, dice);
            return new Property(locationIndex, propertyGroup, utilityRentAction, cost);
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
