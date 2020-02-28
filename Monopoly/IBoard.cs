using System.Collections.Generic;
using Monopoly.Locations;

namespace Monopoly
{
    public interface IBoard
    {
        IList<ILocation> Locations { get; }
        bool PlayerOwnsPropertyGroup(IPlayer player, PropertyGroup propertyGroup);
        int NumberOfRailRoadsOwnedByPlayer(IPlayer player);
        int NumberOfUtilitiesOwned();
        MoveResult MoveToLocation(int currentLocationIndex, int locationsToMove);
    }
}
