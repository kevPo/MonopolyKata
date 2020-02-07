using System;

namespace Monopoly.Actions
{
    public class IncomeTaxAction : IAction
    {
        private readonly decimal incomeTaxRate;
        private readonly int incomeTaxMaxAmount;

        public IncomeTaxAction(int incomeTaxRate, int incomeTaxMaxAmount)
        {
            this.incomeTaxRate = incomeTaxRate;
            this.incomeTaxMaxAmount = incomeTaxMaxAmount;
        }

        public void ProcessAction(IPlayer player)
        {
            var taxAmount = (int)(player.Balance * (incomeTaxRate / 100));
            taxAmount = Math.Min(taxAmount, incomeTaxMaxAmount);
            player.Balance -= taxAmount;
        }
    }
}
