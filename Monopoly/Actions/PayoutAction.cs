namespace Monopoly.Actions
{
    public class PayoutAction : IAction
    {
        private readonly Money amountToPayout;

        public PayoutAction(Money amountToPayout)
        {
            this.amountToPayout = amountToPayout;
        }

        public void ProcessAction(IPlayer player)
        {
            player.Balance = player.Balance.Add(amountToPayout);
        }
    }
}
