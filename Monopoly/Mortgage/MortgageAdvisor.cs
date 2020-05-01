using Monopoly.Locations;

namespace Monopoly.Mortgage
{
    public class MortgageAdvisor : IMortgageAdvisor
    {
        private const int MortgageThreshold = 1000;

        public bool PlayerShouldMortgageProperty(IPlayer player, IProperty property)
        {
            if (property.Owner == null)
            {
                return false;
            }

            if (property.Owner.Name != player.Name)
            {
                return false;
            }

            if (property.IsMortgaged)
            {
                return false;
            }

            if (player.Balance.Amount > MortgageThreshold)
            {
                return false;
            }

            return true;
        }

        public bool PlayerShouldPayOffMortgage(IPlayer player, IProperty property)
        {
            if (property.Owner == null)
            {
                return false;
            }

            if (property.Owner.Name != player.Name)
            {
                return false;
            }

            if (!property.IsMortgaged)
            {
                return false;
            }

            if (player.Balance.Amount <= MortgageThreshold)
            {
                return false;
            }

            return true;
        }
    }
}
