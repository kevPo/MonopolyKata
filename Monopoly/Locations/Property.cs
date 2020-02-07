using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class Property : IProperty
    {
        private IAction purchaseAction;
        private IAction rentAction;
        private IAction currentAction;

        public Property(int locationIndex, int cost = 0, int rent = 0)
        {
            LocationIndex = locationIndex;
            Cost = cost;
            Rent = rent;

            purchaseAction = new PurchasePropertyAction(this);
            rentAction = new NullAction();

            currentAction = purchaseAction;
        }

        public int LocationIndex { get; }
        public IPlayer Owner { get; private set; }
        public int Cost { get; } 
        public int Rent { get; }

        public void PurchaseProperty(IPlayer player)
        {
            Owner = player;
            currentAction = rentAction;
        }

        public void ProcessLandingAction(IPlayer player)
        {
            currentAction.ProcessAction(player);
        }

        public void ProcessPassingAction(IPlayer player)
        {
            // never going to do anything
        }
    }
}
