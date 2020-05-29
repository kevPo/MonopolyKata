using System.Collections.Generic;
using System.Linq;
using Monopoly.Actions;
using Monopoly.Locations;
using Monopoly.Locations.Factories;

namespace Monopoly
{
    public class Board : IBoard
    {
        public IList<ILocation> Locations { get; }

        public IDictionary<int, ILocation> LocationDictionary => Locations.ToDictionary(l => l.LocationIndex);

        public IDictionary<int, IProperty> PropertyDictionary => Locations.OfType<IProperty>().ToDictionary(l => l.LocationIndex);

        public Board(IDice dice)
        {
            var deckFactory = new DeckFactory();

            var utilityFactory = new UtilityFactory(this, dice);
            var railroadFactory = new RailroadFactory(this);
            var realEstateFactory = new RealEstateFactory(this);
            var cardLocationFactory = new CardLocationFactory(deckFactory);
            var nullLocationFactory = new NullLocationFactory();
            var genericLocationFactory = new GenericLocationFactory();

            Locations = new[]
            {
                genericLocationFactory.Create(LocationConstants.GoIndex, new DepositAction(MonopolyConstants.GoPayoutAmount), new DepositAction(MonopolyConstants.GoPayoutAmount)),
                realEstateFactory.Create(LocationConstants.MediterraneanAveIndex),
                cardLocationFactory.CreateCommunityChestLocation(LocationConstants.CommunityChestIndex1),
                realEstateFactory.Create(LocationConstants.BalticAveIndex),
                genericLocationFactory.Create(LocationConstants.IncomeTaxIndex, new IncomeTaxAction(MonopolyConstants.IncomeTaxRate, MonopolyConstants.IncomeTaxMaximumAmount)),
                railroadFactory.Create(LocationConstants.ReadingRailroadIndex),
                realEstateFactory.Create(LocationConstants.OrientalAveIndex),
                cardLocationFactory.CreateChanceLocation(LocationConstants.ChanceIndex1),
                realEstateFactory.Create(LocationConstants.VermontAveIndex),
                realEstateFactory.Create(LocationConstants.ConnecticutAveIndex),
                nullLocationFactory.Create(10),
                realEstateFactory.Create(LocationConstants.StCharlesPlaceIndex),
                utilityFactory.Create(LocationConstants.ElectricCompanyIndex),
                realEstateFactory.Create(LocationConstants.StatesAveIndex),
                realEstateFactory.Create(LocationConstants.VirginiaAveIndex),
                railroadFactory.Create(LocationConstants.PennsylvaniaRailroadIndex),
                realEstateFactory.Create(LocationConstants.StJamesPlaceIndex),
                cardLocationFactory.CreateCommunityChestLocation(LocationConstants.CommunityChestIndex2),
                realEstateFactory.Create(LocationConstants.TennesseeAveIndex),
                realEstateFactory.Create(LocationConstants.NewYorkAveIndex),
                nullLocationFactory.Create(20),
                realEstateFactory.Create(LocationConstants.KentuckyAveIndex),
                cardLocationFactory.CreateChanceLocation(LocationConstants.ChanceIndex2),
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
                cardLocationFactory.CreateCommunityChestLocation(LocationConstants.CommunityChestIndex3),
                realEstateFactory.Create(LocationConstants.PennsylvaniaAveIndex),
                railroadFactory.Create(LocationConstants.ShortLineRailroadIndex),
                cardLocationFactory.CreateChanceLocation(LocationConstants.ChanceIndex3),
                realEstateFactory.Create(LocationConstants.ParkPlaceIndex),
                genericLocationFactory.Create(LocationConstants.LuxuryTaxIndex, new WithdrawAction(MonopolyConstants.LuxuryTaxAmount)),
                realEstateFactory.Create(LocationConstants.BoardwalkIndex)
            };
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
