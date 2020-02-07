namespace Monopoly.Actions
{
    public class PayoutAction : IAction
    {
        private readonly int amountToPayout;

        public PayoutAction(int amountToPayout)
        {
            this.amountToPayout = amountToPayout;
        }

        public void ProcessAction(IPlayer player)
        {
            player.Balance += amountToPayout;
        }
    }
}
