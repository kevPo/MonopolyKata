using Monopoly;
using Monopoly.Locations;

namespace MonopolyTests
{
    public class FakeLocation : ILocation
    {
        public FakeLocation(int locationIndex = 0, IPlayer owner = null)
        {
            LocationIndex = locationIndex;
            Owner = owner;
        }

        public int LocationIndex { get; set; }
        public IPlayer Owner { get; set; }

        public void ProcessLandingAction(IPlayer player)
        {
        }

        public void ProcessPassingAction(IPlayer player)
        {
        }
    }
}
