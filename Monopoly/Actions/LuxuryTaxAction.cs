namespace Monopoly.Actions
{
    public class LuxuryTaxAction : IAction
    {
        private readonly Money luxuryTaxMaxAmount;

        public LuxuryTaxAction(Money luxuryTaxMaxAmount)
        {
            this.luxuryTaxMaxAmount = luxuryTaxMaxAmount;
        }

        public void ProcessAction(IPlayer player)
        {
            player.WithdrawMoney(luxuryTaxMaxAmount);
        }
    }
}
