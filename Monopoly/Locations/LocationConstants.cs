using System.Collections.Generic;

namespace Monopoly.Locations
{
    public static class LocationConstants
    {
        // Indexes
        public const int GoIndex = 0;
        public const int MediterraneanAveIndex = 1;
        public const int CommunityChestIndex1 = 2;
        public const int BalticAveIndex = 3;
        public const int IncomeTaxIndex = 4;
        public const int ReadingRailroadIndex = 5;
        public const int OrientalAveIndex = 6;
        public const int ChanceIndex1 = 7;
        public const int VermontAveIndex = 8;
        public const int ConnecticutAveIndex = 9;
        public const int JailIndex = 10;
        public const int StCharlesPlaceIndex = 11;
        public const int ElectricCompanyIndex = 12;
        public const int StatesAveIndex = 13;
        public const int VirginiaAveIndex = 14;
        public const int PennsylvaniaRailroadIndex = 15;
        public const int StJamesPlaceIndex = 16;
        public const int CommunityChestIndex2 = 17;
        public const int TennesseeAveIndex = 18;
        public const int NewYorkAveIndex = 19;
        public const int FreeParkingIndex = 20;
        public const int KentuckyAveIndex = 21;
        public const int ChanceIndex2 = 22;
        public const int IndianaAveIndex = 23;
        public const int IllinoisAveIndex = 24;
        public const int BAndORailroadIndex = 25;
        public const int AtlanticAveIndex = 26;
        public const int VentnorAveIndex = 27;
        public const int WaterWorksIndex = 28;
        public const int MarvinGardensIndex = 29;
        public const int GoToJailIndex = 30;
        public const int PacificAveIndex = 31;
        public const int NorthCarolinaAveIndex = 32;
        public const int CommunityChestIndex3 = 33;
        public const int PennsylvaniaAveIndex = 34;
        public const int ShortLineRailroadIndex = 35;
        public const int ChanceIndex3 = 36;
        public const int ParkPlaceIndex = 37;
        public const int LuxuryTaxIndex = 38;
        public const int BoardwalkIndex = 39;

        // Costs
        public static readonly Money MediterraneanAveCost = new Money(60);
        public static readonly Money BalticAveCost = new Money(60);
        public static readonly Money OrientalAveCost = new Money(100);
        public static readonly Money VermontAveCost = new Money(100);
        public static readonly Money ConnecticutAveCost = new Money(120);
        public static readonly Money StCharlesPlaceCost = new Money(140);
        public static readonly Money StatesAveCost = new Money(140);
        public static readonly Money VirginiaAveCost = new Money(160);
        public static readonly Money StJamesPlaceCost = new Money(180);
        public static readonly Money TennesseeAveCost = new Money(180);
        public static readonly Money NewYorkAveCost = new Money(200);
        public static readonly Money KentuckyAveCost = new Money(220);
        public static readonly Money IndianaAveCost = new Money(220);
        public static readonly Money IllinoisAveCost = new Money(240);
        public static readonly Money AtlanticAveCost = new Money(260);
        public static readonly Money VentnorAveCost = new Money(260);
        public static readonly Money MarvinGardensCost = new Money(280);
        public static readonly Money PacificAveCost = new Money(300);
        public static readonly Money NorthCarolinaAveCost = new Money(300);
        public static readonly Money PennsylvaniaAveCost = new Money(320);
        public static readonly Money ParkPlaceCost = new Money(350);
        public static readonly Money BoardwalkCost = new Money(400);
        public static readonly Money RailroadCost = new Money(200);
        public static readonly Money UtilityCost = new Money(150);

        // Rents
        public static readonly Money MediterraneanAveRent = new Money(2);
        public static readonly Money BalticAveRent = new Money(4);
        public static readonly Money OrientalAveRent = new Money(6);
        public static readonly Money VermontAveRent = new Money(6);
        public static readonly Money ConnecticutAveRent = new Money(8);
        public static readonly Money StCharlesPlaceRent = new Money(10);
        public static readonly Money StatesAveRent = new Money(10);
        public static readonly Money VirginiaAveRent = new Money(12);
        public static readonly Money StJamesPlaceRent = new Money(14);
        public static readonly Money TennesseeAveRent = new Money(14);
        public static readonly Money NewYorkAveRent = new Money(16);
        public static readonly Money KentuckyAveRent = new Money(18);
        public static readonly Money IndianaAveRent = new Money(18);
        public static readonly Money IllinoisAveRent = new Money(20);
        public static readonly Money AtlanticAveRent = new Money(22);
        public static readonly Money VentnorAveRent = new Money(22);
        public static readonly Money MarvinGardensRent = new Money(24);
        public static readonly Money PacificAveRent = new Money(26);
        public static readonly Money NorthCarolinaAveRent = new Money(26);
        public static readonly Money PennsylvaniaAveRent = new Money(28);
        public static readonly Money ParkPlaceRent = new Money(35);
        public static readonly Money BoardwalkRent = new Money(50);

        // Groups
        public static readonly PropertyGroup PurplePropertyGroup = new PropertyGroup("Purple");
        public static readonly PropertyGroup LightBluePropertyGroup = new PropertyGroup("LightBlue");
        public static readonly PropertyGroup VioletPropertyGroup = new PropertyGroup("Violet");
        public static readonly PropertyGroup OrangePropertyGroup = new PropertyGroup("Orange");
        public static readonly PropertyGroup RedPropertyGroup = new PropertyGroup("Red");
        public static readonly PropertyGroup YellowPropertyGroup = new PropertyGroup("Yellow");
        public static readonly PropertyGroup DarkGreenPropertyGroup = new PropertyGroup("DarkGreen");
        public static readonly PropertyGroup DarkBluePropertyGroup = new PropertyGroup("DarkBlue");
        public static readonly PropertyGroup RailroadGroup = new PropertyGroup("Railroad");
        public static readonly PropertyGroup UtilityGroup = new PropertyGroup("Utility");

        public static readonly IDictionary<int, PropertyGroup> PropertyGroupDictionary = new Dictionary<int, PropertyGroup>
        {
            {MediterraneanAveIndex, PurplePropertyGroup},
            {BalticAveIndex, PurplePropertyGroup},
            {OrientalAveIndex, LightBluePropertyGroup},
            {VermontAveIndex, LightBluePropertyGroup},
            {ConnecticutAveIndex, LightBluePropertyGroup},
            {StCharlesPlaceIndex, VioletPropertyGroup},
            {StatesAveIndex, VioletPropertyGroup},
            {VirginiaAveIndex, VioletPropertyGroup},
            {StJamesPlaceIndex, OrangePropertyGroup},
            {TennesseeAveIndex, OrangePropertyGroup},
            {NewYorkAveIndex, OrangePropertyGroup},
            {KentuckyAveIndex, RedPropertyGroup},
            {IndianaAveIndex, RedPropertyGroup},
            {IllinoisAveIndex, RedPropertyGroup},
            {AtlanticAveIndex, YellowPropertyGroup},
            {VentnorAveIndex, YellowPropertyGroup},
            {MarvinGardensIndex, YellowPropertyGroup},
            {PacificAveIndex, DarkGreenPropertyGroup},
            {NorthCarolinaAveIndex, DarkGreenPropertyGroup},
            {PennsylvaniaAveIndex, DarkGreenPropertyGroup},
            {ParkPlaceIndex, DarkBluePropertyGroup},
            {BoardwalkIndex, DarkBluePropertyGroup}
        };

        public static readonly IDictionary<int, Money> PropertyCostDictionary = new Dictionary<int, Money>
        {
            {MediterraneanAveIndex, MediterraneanAveCost},
            {BalticAveIndex, BalticAveCost},
            {OrientalAveIndex, OrientalAveCost},
            {VermontAveIndex, VermontAveCost},
            {ConnecticutAveIndex, ConnecticutAveCost},
            {StCharlesPlaceIndex, StCharlesPlaceCost},
            {StatesAveIndex, StatesAveCost},
            {VirginiaAveIndex, VirginiaAveCost},
            {StJamesPlaceIndex, StJamesPlaceCost},
            {TennesseeAveIndex, TennesseeAveCost},
            {NewYorkAveIndex, NewYorkAveCost},
            {KentuckyAveIndex, KentuckyAveCost},
            {IndianaAveIndex, IndianaAveCost},
            {IllinoisAveIndex, IllinoisAveCost},
            {AtlanticAveIndex, AtlanticAveCost},
            {VentnorAveIndex, VentnorAveCost},
            {MarvinGardensIndex, MarvinGardensCost},
            {PacificAveIndex, PacificAveCost},
            {NorthCarolinaAveIndex, NorthCarolinaAveCost},
            {PennsylvaniaAveIndex, PennsylvaniaAveCost},
            {ParkPlaceIndex, ParkPlaceCost},
            {BoardwalkIndex, BoardwalkCost}
        };

        public static readonly IDictionary<int, Money> PropertyRentDictionary = new Dictionary<int, Money>
        {
            {MediterraneanAveIndex, MediterraneanAveRent},
            {BalticAveIndex, BalticAveRent},
            {OrientalAveIndex, OrientalAveRent},
            {VermontAveIndex, VermontAveRent},
            {ConnecticutAveIndex, ConnecticutAveRent},
            {StCharlesPlaceIndex, StCharlesPlaceRent},
            {StatesAveIndex, StatesAveRent},
            {VirginiaAveIndex, VirginiaAveRent},
            {StJamesPlaceIndex, StJamesPlaceRent},
            {TennesseeAveIndex, TennesseeAveRent},
            {NewYorkAveIndex, NewYorkAveRent},
            {KentuckyAveIndex, KentuckyAveRent},
            {IndianaAveIndex, IndianaAveRent},
            {IllinoisAveIndex, IllinoisAveRent},
            {AtlanticAveIndex, AtlanticAveRent},
            {VentnorAveIndex, VentnorAveRent},
            {MarvinGardensIndex, MarvinGardensRent},
            {PacificAveIndex, PacificAveRent},
            {NorthCarolinaAveIndex, NorthCarolinaAveRent},
            {PennsylvaniaAveIndex, PennsylvaniaAveRent},
            {ParkPlaceIndex, ParkPlaceRent},
            {BoardwalkIndex, BoardwalkRent}
        };
    }
}
