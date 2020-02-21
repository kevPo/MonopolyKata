using Monopoly.Locations;

namespace Monopoly.Actions
{
    public class UtilityRentAction : IPropertyAction
    {
        private const int OneUtilityOwnedRentMultiplier = 4;
        private const int MultipleUtilitiesOwnedRentMultiplier = 10;
        private readonly IBoard board;
        private readonly IDice dice;

        public UtilityRentAction(IBoard board, IDice dice)
        {
            this.board = board;
            this.dice = dice;
        }

        public void ProcessAction(IPlayer player, IProperty property)
        {
            var rent = new Money(dice.LastRoll * GetMultiplierForNumberOfUtilitiesOwned());

            player.WithdrawMoney(rent);
            property.Owner.DepositMoney(rent);   
        }

        private int GetMultiplierForNumberOfUtilitiesOwned()
        {
            return board.NumberOfUtilitiesOwned() == 1 
                ? OneUtilityOwnedRentMultiplier 
                : MultipleUtilitiesOwnedRentMultiplier;
        }
    }
}
