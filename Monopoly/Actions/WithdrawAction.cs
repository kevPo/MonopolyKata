namespace Monopoly.Actions
{
    public class WithdrawAction : IAction
    {
        private readonly Money amountToWithdraw;

        public WithdrawAction(Money amountToWithdraw)
        {
            this.amountToWithdraw = amountToWithdraw;
        }

        public void ProcessAction(IPlayer player)
        {
            player.WithdrawMoney(amountToWithdraw);
        }
    }
}
