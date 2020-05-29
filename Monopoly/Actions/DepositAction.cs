namespace Monopoly.Actions
{
    public class DepositAction : IAction
    {
        private readonly Money amountToDeposit;

        public DepositAction(Money amountToDeposit)
        {
            this.amountToDeposit = amountToDeposit;
        }

        public void ProcessAction(IPlayer player)
        {
            player.DepositMoney(amountToDeposit);
        }
    }
}
