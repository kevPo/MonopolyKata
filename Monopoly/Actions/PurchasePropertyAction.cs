using Monopoly.Locations;

namespace Monopoly.Actions
{
    public class PurchasePropertyAction : IAction
    {
        private readonly int cost;

        public PurchasePropertyAction(int cost)
        {
            this.cost = cost;
        }

        public void ProcessAction(IPlayer player, ILocation location)
        {
            if (location.Owner == null)
            {
                var newBalance = player.Balance - cost;
                if (newBalance >= 0)
                {
                    location.Owner = player;
                    player.Balance -= cost;
                }
            }
        }
    }
}
