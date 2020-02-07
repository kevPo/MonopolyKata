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
            if (property.Owner == null)
            {
                var newBalance = player.Balance - property.Cost;
                if (newBalance >= 0)
                {
                    player.Balance = newBalance;
                    property.PurchaseProperty(player);
                }
            }
        }
    }
}
