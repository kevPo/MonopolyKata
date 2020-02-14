using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class Property : IProperty
    {
        private IAction purchaseAction;
        private IAction rentAction;
        private IAction currentAction;

        public Property(int locationIndex, Money? cost = null, Money? rent = null)
        {
            LocationIndex = locationIndex;
            Cost = cost ?? new Money(0);
            Rent = rent ?? new Money(0);

            purchaseAction = new PurchasePropertyAction(this);
            rentAction = new NullAction();

            currentAction = purchaseAction;
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
