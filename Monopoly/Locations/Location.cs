using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class Location : ILocation
    {
        private readonly IAction landingAction;
        private readonly IAction passingAction;

        public Location(int locationIndex, IAction landingAction, IAction passingAction)
        {
            LocationIndex = locationIndex;
            this.landingAction = landingAction;
            this.passingAction = passingAction;
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
