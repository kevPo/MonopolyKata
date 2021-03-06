﻿using System.Collections.Generic;
using System.Linq;
using Monopoly;
using Monopoly.Locations;

namespace MonopolyTests.Fakes
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
            Locations = Enumerable.Range(0, 40).Select(i => new FakeProperty(i)).ToList<ILocation>();
        }

        public IList<ILocation> Locations { get; }

        public IDictionary<int, ILocation> LocationDictionary => Locations.ToDictionary(l => l.LocationIndex);

        public IDictionary<int, IProperty> PropertyDictionary => Locations.OfType<IProperty>().ToDictionary(l => l.LocationIndex);

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
