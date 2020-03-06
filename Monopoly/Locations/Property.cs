using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class Property : IProperty
    {
        private readonly IPropertyAction purchaseAction;
        private readonly IPropertyAction rentAction;
        private IPropertyAction currentAction;

        public Property(int locationIndex, PropertyGroup propertyGroup, IPropertyAction rentAction, Money? cost = null, Money? rent = null, bool isMortgaged = false)
        {
            LocationIndex = locationIndex;
            PropertyGroup = propertyGroup;
            Cost = cost ?? new Money(0);
            Rent = rent ?? new Money(0);
            IsMortgaged = isMortgaged;

            purchaseAction = new PurchasePropertyAction();
            this.rentAction = rentAction;

            currentAction = purchaseAction;
        }

        public int LocationIndex { get; }
        public PropertyGroup PropertyGroup { get; }
        public IPlayer Owner { get; private set; }
        public Money Cost { get; } 
        public Money Rent { get; }
        public bool IsMortgaged { get; private set; }

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
            currentAction.ProcessAction(player, this);
        }

        public void ProcessPassingAction(IPlayer player)
        {
            // never going to do anything
        }

        public void MortgageProperty()
        {
            IsMortgaged = true;
        }

        public void UnmortgageProperty()
        {
            IsMortgaged = false;
        }
    }
}
