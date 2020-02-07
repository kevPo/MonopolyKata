using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class Location : ILocation
    {
        private readonly IAction landingAction;
        private readonly IAction passingAction;

        public Location(int locationIndex, IPlayer owner = null, IAction landingAction = null, IAction passingAction = null)
        {
            LocationIndex = locationIndex;
            Owner = owner;
            this.landingAction = landingAction ?? new NullAction();
            this.passingAction = passingAction ?? new NullAction();
        }

        public int LocationIndex { get; }
        public IPlayer Owner { get; set; }

        public void ProcessLandingAction(IPlayer player)
        {
            landingAction.ProcessAction(player, this);
        }

        public void ProcessPassingAction(IPlayer player)
        {
            passingAction.ProcessAction(player, this);
        }
    }
}
