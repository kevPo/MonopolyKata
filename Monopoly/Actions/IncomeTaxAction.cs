using System;

namespace Monopoly.Actions
{
    public class IncomeTaxAction : IAction
    {
        private readonly decimal incomeTaxRate;
        private readonly Money incomeTaxMaxAmount;

        public IncomeTaxAction(int incomeTaxRate, Money incomeTaxMaxAmount)
        {
            this.incomeTaxRate = incomeTaxRate;
            this.incomeTaxMaxAmount = incomeTaxMaxAmount;
        }

        public void ProcessAction(IPlayer player)
        {
            // TODO: should we look into this?
            var taxAmount = (int)(player.Balance.Amount * (incomeTaxRate / 100));
            taxAmount = Math.Min(taxAmount, incomeTaxMaxAmount.Amount);
            player.Balance = player.Balance.Remove(new Money(taxAmount));
        }
    }
}
