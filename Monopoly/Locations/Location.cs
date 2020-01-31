using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class Location : ILocation
    {
        private readonly IAction passingAction;
        private readonly IAction landingAction;

        public Location(int locationIndex, IAction passingAction, IAction landingAction)
        {
            LocationIndex = locationIndex;
            this.passingAction = passingAction;
            this.landingAction = landingAction;
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
