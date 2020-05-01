using Monopoly.Locations;

namespace Monopoly
{
    public class Player : IPlayer
    {
        public string Name { get;  }
        public Money Balance { get; private set; }
        public int Location { get; private set; }
        public bool IsInJail { get; private set; }
        public int NumberOfEscapeAttempts { get; private set; }

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

        public bool HasReachedMaxEscapeAttempts()
        {
            return NumberOfEscapeAttempts == MonopolyConstants.MaximumNumberOfEscapeAttempts;
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

        public void MoveToLocation(int location)
        {
            if (!IsInJail)
            {
                Location = location;
            }
        }

        public void GoToJail()
        {
            Location = LocationConstants.JailIndex;
            IsInJail = true;
            NumberOfEscapeAttempts = 0;
        }

        public void GetOutOfJail()
        {
            IsInJail = false;
            NumberOfEscapeAttempts = 0;
        }

        public void AddEscapeAttempt()
        {
            NumberOfEscapeAttempts++;
        }
    }
}
