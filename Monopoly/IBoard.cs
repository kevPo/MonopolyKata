using Monopoly.Locations;

namespace Monopoly
{
    public interface IBoard
    {
        bool PlayerOwnsPropertyGroup(IPlayer player, PropertyGroup propertyGroup);
        int NumberOfRailRoadsOwnedByPlayer(IPlayer player);
        int NumberOfUtilitiesOwned();
    }
}
