using Monopoly.Locations;

namespace Monopoly.Actions
{
    public class LuxuryTaxAction : IAction
    {
        private readonly int luxuryTaxMaxAmount;

        public LuxuryTaxAction(int luxuryTaxMaxAmount)
        {
            this.luxuryTaxMaxAmount = luxuryTaxMaxAmount;
        }

        public void ProcessAction(IPlayer player, ILocation location)
        {
            player.Balance -= luxuryTaxMaxAmount;
        }
    }
}
