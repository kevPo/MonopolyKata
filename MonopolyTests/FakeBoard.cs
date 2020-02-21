using Monopoly;
using Monopoly.Locations;

namespace MonopolyTests
{
    public class FakeBoard : IBoard
    {
        private readonly int numberOfRailroadsOwnedByPlayer;
        private readonly int numberOfUtilitiesOwned;
        private readonly bool playerOwnsPropertyGroup;

        public FakeBoard(int numberOfRailroadsOwnedByPlayer = 0, int numberOfUtilitiesOwned = 0, bool playerOwnsPropertyGroup = false)
        {
            this.numberOfRailroadsOwnedByPlayer = numberOfRailroadsOwnedByPlayer;
            this.numberOfUtilitiesOwned = numberOfUtilitiesOwned;
            this.playerOwnsPropertyGroup = playerOwnsPropertyGroup;
        }

        public int NumberOfRailRoadsOwnedByPlayer(IPlayer player)
        {
            return numberOfRailroadsOwnedByPlayer;
        }

        public int NumberOfUtilitiesOwned()
        {
            return numberOfUtilitiesOwned;
        }

        public bool PlayerOwnsPropertyGroup(IPlayer player, PropertyGroup propertyGroup)
        {
            return playerOwnsPropertyGroup;
        }
    }
}
