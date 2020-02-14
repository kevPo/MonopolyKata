namespace Monopoly
{
    public class Player : IPlayer
    {
        public string Name { get;  }
        public Money Balance { get; private set; }
        public int Location { get; set; }

        public Player(string name, Money? balance = null, int location = 0)
        {
            Name = name;
            Balance = balance ?? new Money(0);
            Location = location;
        }

        public bool HasAvailableFunds(Money amount)
        {
            return Balance.Amount >= amount.Amount;
        }

        public bool DepositMoney(Money amount)
        {
            Balance = Balance.Add(amount);
            return true;
        }

        public bool WithdrawMoney(Money amount)
        {
            if (HasAvailableFunds(amount))
            {
                Balance = Balance.Remove(amount);
                return true;
            }

            return false;
        }

        public Turn TakeTurn(int turnOrder, IDice dice, Board board)
        {
            var rolled = dice.Roll();
            var result = board.MoveToLocation(Location, rolled);
            Location = result.CurrentLocation.LocationIndex;

            foreach (var location in result.LocationHistory)
            {
                location.ProcessPassingAction(this);
            }

            result.CurrentLocation.ProcessLandingAction(this);

            return new Turn
            {
                TurnOrder = turnOrder,
                Player = Name,
                Location = Location
            };
        }
    }
}
