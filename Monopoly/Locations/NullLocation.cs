namespace Monopoly.Locations
{
    public class NullLocation : ILocation
    {
        public NullLocation(int locationIndex)
        {
            LocationIndex = locationIndex;
        }

        public int LocationIndex { get; }

        public void ProcessLandingAction(IPlayer player)
        {
        }

        public void ProcessPassingAction(IPlayer player)
        {
        }
    }
}
