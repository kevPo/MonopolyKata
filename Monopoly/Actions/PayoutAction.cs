using Monopoly.Locations;

namespace Monopoly.Actions
{
    public class PayoutAction : IAction
    {
        private readonly int amountToPayout;

        public PayoutAction(int amountToPayout)
        {
            this.amountToPayout = amountToPayout;
        }

        public void ProcessAction(IPlayer player, ILocation location)
        {
            player.Balance += amountToPayout;
        }
    }
}
