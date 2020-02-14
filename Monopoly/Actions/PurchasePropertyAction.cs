using Monopoly.Locations;

namespace Monopoly.Actions
{
    public class PurchasePropertyAction : IAction
    {
        private readonly IProperty property;

        public PurchasePropertyAction(IProperty property)
        {
            this.property = property;
        }

        public void ProcessAction(IPlayer player)
        {
            if (property.IsUnowned() && player.HasAvailableFunds(property.Cost))
            {
                player.WithdrawMoney(property.Cost);
                property.TransitionOwnership(player);
            }
        }
    }
}
