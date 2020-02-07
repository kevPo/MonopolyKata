using Monopoly;
using Monopoly.Locations;

namespace MonopolyTests
{
    public class FakeProperty : IProperty
    {
        public FakeProperty(int locationIndex = 0, IPlayer owner = null, int cost = 0, int rent = 0)
        {
            LocationIndex = locationIndex;
            Owner = owner;
            Cost = cost;
            Rent = rent;
        }

        public int LocationIndex { get; }
        public IPlayer Owner { get; private set; }
        public int Cost { get; }
        public int Rent { get; }

        public void PurchaseProperty(IPlayer player)
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
