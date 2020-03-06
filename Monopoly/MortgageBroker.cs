using System;
using Monopoly.Locations;

namespace Monopoly
{
    public class MortgageBroker : IMortgageBroker
    {
        public const double MortgageRate = .9;

        public bool TakeOutMortgage(IPlayer player, IProperty property)
        {
            if (!CanMortgageProperty(player, property))
            {
                return false;
            }

            var mortgageAmount = Convert.ToInt32(Math.Floor(property.Cost.Amount * MortgageRate));
            player.DepositMoney(new Money(mortgageAmount));
            property.MortgageProperty();

            return true;
        }

        public bool PayOffMortgage(IPlayer player, IProperty property)
        {
            if (!CanPayOffMortgage(player, property))
            {
                return false;
            }

            var mortgagePayoff = property.Cost;
            player.WithdrawMoney(mortgagePayoff);
            property.UnmortgageProperty();

            return true;
        }

        private static bool CanMortgageProperty(IPlayer player, IProperty property)
        {
            if (!PlayerOwnsProperty(player, property))
                return false;

            if (property.IsMortgaged)
                return false;

            return true;
        }

        private static bool CanPayOffMortgage(IPlayer player, IProperty property)
        {
            if (!PlayerOwnsProperty(player, property))
                return false;

            if (!property.IsMortgaged)
                return false;

            return true;
        }

        private static bool PlayerOwnsProperty(IPlayer player, IProperty property)
        {
            if (property.Owner == null)
                return false;

            if (property.Owner.Name != player.Name)
                return false;

            return true;
        }
    }
}
