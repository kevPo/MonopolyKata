using System.Collections.Generic;
using Monopoly.Locations;

namespace Monopoly
{
    public interface IBoard
    {
        IList<ILocation> Locations { get; }
        IDictionary<int, ILocation> LocationDictionary { get; }
        IDictionary<int, IProperty> PropertyDictionary { get; }
        bool PlayerOwnsPropertyGroup(IPlayer player, PropertyGroup propertyGroup);
        int NumberOfRailRoadsOwnedByPlayer(IPlayer player);
        int NumberOfUtilitiesOwned();
    }
}
