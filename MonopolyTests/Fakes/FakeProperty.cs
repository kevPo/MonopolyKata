using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations;

namespace MonopolyTests.Fakes
{
    public class FakeProperty : IProperty
    {
        public FakeProperty(int locationIndex = 0, IPlayer owner = null, Money? cost = null, Money? rent = null, bool isMortgaged = false)
        {
            LocationIndex = locationIndex;
            Owner = owner;
            Cost = cost ?? new Money(0);
            Rent = rent ?? new Money(0);
            LandedPlayers = new List<string>();
            IsMortgaged = isMortgaged;
        }

        public int LocationIndex { get; }
        public PropertyGroup PropertyGroup { get; }
        public IPlayer Owner { get; private set; }
        public Money Cost { get; }
        public Money Rent { get; }
        public IList<string> LandedPlayers { get; }
        public bool IsMortgaged { get; private set; }

        public bool IsUnowned()
        {
            return Owner == null;
        }

        public void TransitionOwnership(IPlayer player)
        {
            Owner = player;
        }

        public void ProcessLandingAction(IPlayer player)
        {
            LandedPlayers.Add(player.Name);
        }

        public void ProcessPassingAction(IPlayer player)
        {
        }

        public void MortgageProperty()
        {
            IsMortgaged = true;
        }

        public void UnmortgageProperty()
        {
            IsMortgaged = false;
        }
    }
}
