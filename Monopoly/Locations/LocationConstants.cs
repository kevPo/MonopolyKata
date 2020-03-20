namespace Monopoly.Locations
{
    public static class LocationConstants
    {
        // Indexes
        public const int GoIndex = 0;
        public const int MediterraneanAveIndex = 1;
        // Community Chest
        public const int BalticAveIndex = 3;
        public const int IncomeTaxIndex = 4;
        public const int ReadingRailroadIndex = 5;
        public const int OrientalAveIndex = 6;
        // Chance
        public const int VermontAveIndex = 8;
        public const int ConnecticutAveIndex = 9;
        public const int JailIndex = 10;
        public const int StCharlesPlaceIndex = 11;
        public const int ElectricCompanyIndex = 12;
        public const int StatesAveIndex = 13;
        public const int VirginiaAveIndex = 14;
        public const int PennsylvaniaRailroadIndex = 15;
        public const int StJamesPlaceIndex = 16;
        // Community Chest
        public const int TennesseeAveIndex = 18;
        public const int NewYorkAveIndex = 19;
        // Free Parking
        public const int KentuckyAveIndex = 21;
        // Chance
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
        // Community Chest
        public const int PennsylvaniaAveIndex = 34;
        public const int ShortLineRailroadIndex = 35;
        // Chance
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
    }
}
