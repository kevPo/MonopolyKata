using Monopoly.Locations;

namespace Monopoly.Actions
{
    public class RealEstateRentAction : IPropertyAction
    {
        private readonly IBoard board;

        public RealEstateRentAction(IBoard board)
        {
            this.board = board;
        }

        public void ProcessAction(IPlayer player, IProperty property)
        {
            var rent = property.Rent;

            if (board.PlayerOwnsPropertyGroup(property.Owner, property.PropertyGroup))
            {
                rent = new Money(rent.Amount * 2);
            }

            player.WithdrawMoney(rent);
            property.Owner.DepositMoney(rent);
        }
    }
}
