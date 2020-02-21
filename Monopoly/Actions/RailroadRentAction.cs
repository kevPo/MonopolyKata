using Monopoly.Locations;

namespace Monopoly.Actions
{
    public class RailroadRentAction : IPropertyAction
    {
        private const int BaseRentAmount = 25;
        private readonly IBoard board;

        public RailroadRentAction(IBoard board)
        {
            this.board = board;
        }

        public void ProcessAction(IPlayer player, IProperty property)
        {
            var numberOfRailroadsOwnedByPlayer = board.NumberOfRailRoadsOwnedByPlayer(property.Owner);
            var rent = new Money(BaseRentAmount * numberOfRailroadsOwnedByPlayer);

            player.WithdrawMoney(rent);
            property.Owner.DepositMoney(rent);    
        }
    }
}
