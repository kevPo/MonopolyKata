using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class Location : ILocation
    {
        private readonly IAction landingAction;
        private readonly IAction passingAction;

        public Location(int locationIndex, IAction landingAction = null, IAction passingAction = null)
        {
            LocationIndex = locationIndex;
            this.landingAction = landingAction ?? new NullAction();
            this.passingAction = passingAction ?? new NullAction();
        }

        public int LocationIndex { get; }

        public void ProcessLandingAction(IPlayer player)
        {
            landingAction.ProcessAction(player);
        }

        public void ProcessPassingAction(IPlayer player)
        {
            passingAction.ProcessAction(player);
        }
    }
}
