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

        public Board(IDice dice)
        {
            Locations = new ILocation[]
            {
                new Location(LocationConstants.GoIndex, landingAction: new PayoutAction(MonopolyConstants.GoPayoutAmount), passingAction: new PayoutAction(MonopolyConstants.GoPayoutAmount)),
                new Property(LocationConstants.MediterraneanAveIndex, LocationConstants.PurplePropertyGroup, new RealEstateRentAction(this), LocationConstants.MediterraneanAveCost, LocationConstants.MediterraneanAveRent),
                new NullLocation(2),
                new Property(LocationConstants.BalticAveIndex, LocationConstants.PurplePropertyGroup, new RealEstateRentAction(this), LocationConstants.BalticAveCost, LocationConstants.BalticAveRent),
                new Location(LocationConstants.IncomeTaxIndex, landingAction: new IncomeTaxAction(MonopolyConstants.IncomeTaxRate, MonopolyConstants.IncomeTaxMaximumAmount)),
                new Property(LocationConstants.ReadingRailroadIndex, LocationConstants.RailroadGroup, new RailroadRentAction(this), LocationConstants.RailroadCost),
                new Property(LocationConstants.OrientalAveIndex, LocationConstants.LightBluePropertyGroup, new RealEstateRentAction(this), LocationConstants.OrientalAveCost, LocationConstants.OrientalAveRent),
                new NullLocation(7),
                new Property(LocationConstants.VermontAveIndex, LocationConstants.LightBluePropertyGroup, new RealEstateRentAction(this), LocationConstants.VermontAveCost, LocationConstants.VermontAveRent),
                new Property(LocationConstants.ConnecticutAveIndex, LocationConstants.LightBluePropertyGroup, new RealEstateRentAction(this), LocationConstants.ConnecticutAveCost, LocationConstants.ConnecticutAveRent),
                new NullLocation(10),
                new Property(LocationConstants.StCharlesPlaceIndex, LocationConstants.VioletPropertyGroup, new RealEstateRentAction(this), LocationConstants.StCharlesPlaceCost, LocationConstants.StCharlesPlaceRent),
                new Property(LocationConstants.ElectricCompanyIndex, LocationConstants.UtilityGroup, new UtilityRentAction(this, dice), LocationConstants.UtilityCost),
                new Property(LocationConstants.StatesAveIndex, LocationConstants.VioletPropertyGroup, new RealEstateRentAction(this), LocationConstants.StatesAveCost, LocationConstants.StatesAveRent),
                new Property(LocationConstants.VirginiaAveIndex, LocationConstants.VioletPropertyGroup, new RealEstateRentAction(this), LocationConstants.VirginiaAveCost, LocationConstants.VirginiaAveRent),
                new Property(LocationConstants.PennsylvaniaRailroadIndex, LocationConstants.RailroadGroup, new RailroadRentAction(this), LocationConstants.RailroadCost),
                new Property(LocationConstants.StJamesPlaceIndex, LocationConstants.OrangePropertyGroup, new RealEstateRentAction(this), LocationConstants.StJamesPlaceCost, LocationConstants.StJamesPlaceRent),
                new NullLocation(17),
                new Property(LocationConstants.TennesseeAveIndex, LocationConstants.OrangePropertyGroup, new RealEstateRentAction(this), LocationConstants.TennesseeAveCost, LocationConstants.TennesseeAveRent),
                new Property(LocationConstants.NewYorkAveIndex, LocationConstants.OrangePropertyGroup, new RealEstateRentAction(this), LocationConstants.NewYorkAveCost, LocationConstants.NewYorkAveRent),
                new NullLocation(20),
                new Property(LocationConstants.KentuckyAveIndex, LocationConstants.RedPropertyGroup, new RealEstateRentAction(this), LocationConstants.KentuckyAveCost, LocationConstants.KentuckyAveRent),
                new NullLocation(22),
                new Property(LocationConstants.IndianaAveIndex, LocationConstants.RedPropertyGroup, new RealEstateRentAction(this), LocationConstants.IndianaAveCost, LocationConstants.IndianaAveRent),
                new Property(LocationConstants.IllinoisAveIndex, LocationConstants.RedPropertyGroup, new RealEstateRentAction(this), LocationConstants.IllinoisAveCost, LocationConstants.IllinoisAveRent),
                new Property(LocationConstants.BAndORailroadIndex, LocationConstants.RailroadGroup, new RailroadRentAction(this), LocationConstants.RailroadCost),
                new Property(LocationConstants.AtlanticAveIndex, LocationConstants.YellowPropertyGroup, new RealEstateRentAction(this), LocationConstants.AtlanticAveCost, LocationConstants.AtlanticAveRent),
                new Property(LocationConstants.VentnorAveIndex, LocationConstants.YellowPropertyGroup, new RealEstateRentAction(this), LocationConstants.VentnorAveCost, LocationConstants.VentnorAveRent),
                new Property(LocationConstants.WaterWorksIndex, LocationConstants.UtilityGroup, new UtilityRentAction(this, dice), LocationConstants.UtilityCost),
                new Property(LocationConstants.MarvinGardensIndex, LocationConstants.YellowPropertyGroup, new RealEstateRentAction(this), LocationConstants.MarvinGardensCost, LocationConstants.MarvinGardensRent),
                new Location(LocationConstants.GoToJailIndex, landingAction: new RelocateAction(LocationConstants.JustVisitingIndex)),
                new Property(LocationConstants.PacificAveIndex, LocationConstants.DarkGreenPropertyGroup, new RealEstateRentAction(this), LocationConstants.PacificAveCost, LocationConstants.PacificAveRent),
                new Property(LocationConstants.NorthCarolinaAveIndex, LocationConstants.DarkGreenPropertyGroup, new RealEstateRentAction(this), LocationConstants.NorthCarolinaAveCost, LocationConstants.NorthCarolinaAveRent),
                new NullLocation(33),
                new Property(LocationConstants.PennsylvaniaAveIndex, LocationConstants.DarkGreenPropertyGroup, new RealEstateRentAction(this), LocationConstants.PennsylvaniaAveCost, LocationConstants.PennsylvaniaAveRent),
                new Property(LocationConstants.ShortLineRailroadIndex, LocationConstants.RailroadGroup, new RailroadRentAction(this), LocationConstants.RailroadCost),
                new NullLocation(36),
                new Property(LocationConstants.ParkPlaceIndex, LocationConstants.DarkBluePropertyGroup, new RealEstateRentAction(this), LocationConstants.ParkPlaceCost, LocationConstants.ParkPlaceRent),
                new Location(LocationConstants.LuxuryTaxIndex, landingAction: new LuxuryTaxAction(MonopolyConstants.LuxuryTaxAmount)),
                new Property(LocationConstants.BoardwalkIndex, LocationConstants.DarkBluePropertyGroup, new RealEstateRentAction(this), LocationConstants.BoardwalkCost, LocationConstants.BoardwalkRent),
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
