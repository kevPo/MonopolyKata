using Monopoly;
using Monopoly.Locations;

namespace MonopolyTests
{
    public class FakeProperty : IProperty
    {
        public FakeProperty(int locationIndex = 0, IPlayer owner = null, Money? cost = null, Money? rent = null)
        {
            LocationIndex = locationIndex;
            Owner = owner;
            Cost = cost ?? new Money(0);
            Rent = rent ?? new Money(0);
        }

        public int LocationIndex { get; }
        public IPlayer Owner { get; private set; }
        public Money Cost { get; }
        public Money Rent { get; }

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
        }

        public void ProcessPassingAction(IPlayer player)
        {
        }
    }
}
