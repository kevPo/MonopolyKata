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
                new Location(LocationConstants.GoIndex, landingAction: new PayoutAction(MonopolyConstants.GoPayoutAmount), passingAction: new PayoutAction(MonopolyConstants.GoPayoutAmount)),
                new Property(LocationConstants.MediterraneanAveIndex, LocationConstants.PurplePropertyGroup, LocationConstants.MediterraneanAveCost, LocationConstants.MediterraneanAveRent),
                new NullLocation(2),
                new Property(LocationConstants.BalticAveIndex, LocationConstants.PurplePropertyGroup, LocationConstants.BalticAveCost, LocationConstants.BalticAveRent),
                new Location(LocationConstants.IncomeTaxIndex, landingAction: new IncomeTaxAction(MonopolyConstants.IncomeTaxRate, MonopolyConstants.IncomeTaxMaximumAmount)),
                new NullLocation(5),
                new Property(LocationConstants.OrientalAveIndex, LocationConstants.LightBluePropertyGroup, LocationConstants.OrientalAveCost, LocationConstants.OrientalAveRent),
                new NullLocation(7),
                new Property(LocationConstants.VermontAveIndex, LocationConstants.LightBluePropertyGroup, LocationConstants.VermontAveCost, LocationConstants.VermontAveRent),
                new Property(LocationConstants.ConnecticutAveIndex, LocationConstants.LightBluePropertyGroup, LocationConstants.ConnecticutAveCost, LocationConstants.ConnecticutAveRent),
                new NullLocation(10),
                new Property(LocationConstants.StCharlesPlaceIndex, LocationConstants.VioletPropertyGroup, LocationConstants.StCharlesPlaceCost, LocationConstants.StCharlesPlaceRent),
                new NullLocation(12),
                new Property(LocationConstants.StatesAveIndex, LocationConstants.VioletPropertyGroup, LocationConstants.StatesAveCost, LocationConstants.StatesAveRent),
                new Property(LocationConstants.VirginiaAveIndex, LocationConstants.VioletPropertyGroup, LocationConstants.VirginiaAveCost, LocationConstants.VirginiaAveRent),
                new NullLocation(15),
                new Property(LocationConstants.StJamesPlaceIndex, LocationConstants.OrangePropertyGroup, LocationConstants.StJamesPlaceCost, LocationConstants.StJamesPlaceRent),
                new NullLocation(17),
                new Property(LocationConstants.TennesseeAveIndex, LocationConstants.OrangePropertyGroup, LocationConstants.TennesseeAveCost, LocationConstants.TennesseeAveRent),
                new Property(LocationConstants.NewYorkAveIndex, LocationConstants.OrangePropertyGroup, LocationConstants.NewYorkAveCost, LocationConstants.NewYorkAveRent),
                new NullLocation(20),
                new Property(LocationConstants.KentuckyAveIndex, LocationConstants.RedPropertyGroup, LocationConstants.KentuckyAveCost, LocationConstants.KentuckyAveRent),
                new NullLocation(22),
                new Property(LocationConstants.IndianaAveIndex, LocationConstants.RedPropertyGroup, LocationConstants.IndianaAveCost, LocationConstants.IndianaAveRent),
                new Property(LocationConstants.IllinoisAveIndex, LocationConstants.RedPropertyGroup, LocationConstants.IllinoisAveCost, LocationConstants.IllinoisAveRent),
                new NullLocation(25),
                new Property(LocationConstants.AtlanticAveIndex, LocationConstants.YellowPropertyGroup, LocationConstants.AtlanticAveCost, LocationConstants.AtlanticAveRent),
                new Property(LocationConstants.VentnorAveIndex, LocationConstants.YellowPropertyGroup, LocationConstants.VentnorAveCost, LocationConstants.VentnorAveRent),
                new NullLocation(28),
                new Property(LocationConstants.MarvinGardensIndex, LocationConstants.YellowPropertyGroup, LocationConstants.MarvinGardensCost, LocationConstants.MarvinGardensRent),
                new Location(LocationConstants.GoToJailIndex, landingAction: new RelocateAction(LocationConstants.JustVisitingIndex)),
                new Property(LocationConstants.PacificAveIndex, LocationConstants.DarkGreenPropertyGroup, LocationConstants.PacificAveCost, LocationConstants.PacificAveRent),
                new Property(LocationConstants.NorthCarolinaAveIndex, LocationConstants.DarkGreenPropertyGroup, LocationConstants.NorthCarolinaAveCost, LocationConstants.NorthCarolinaAveRent),
                new NullLocation(33),
                new Property(LocationConstants.PennsylvaniaAveIndex, LocationConstants.DarkGreenPropertyGroup, LocationConstants.PennsylvaniaAveCost, LocationConstants.PennsylvaniaAveRent),
                new NullLocation(35),
                new NullLocation(36),
                new Property(LocationConstants.ParkPlaceIndex, LocationConstants.DarkBluePropertyGroup, LocationConstants.ParkPlaceCost, LocationConstants.ParkPlaceRent),
                new Location(LocationConstants.LuxuryTaxIndex, landingAction: new LuxuryTaxAction(MonopolyConstants.LuxuryTaxAmount)),
                new Property(LocationConstants.BoardwalkIndex, LocationConstants.DarkBluePropertyGroup, LocationConstants.BoardwalkCost, LocationConstants.BoardwalkRent),
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
