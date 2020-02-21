using Monopoly.Locations;

namespace Monopoly.Actions
{
    public class PurchasePropertyAction : IPropertyAction
    {
        public void ProcessAction(IPlayer player, IProperty property)
        {
            if (property.IsUnowned() && player.HasAvailableFunds(property.Cost))
            {
                player.WithdrawMoney(property.Cost);
                property.TransitionOwnership(player);
            }
        }
    }
}
