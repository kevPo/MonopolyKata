using System;

namespace Monopoly
{
    public struct Money
    {
        public Money(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; }

        public override string ToString()
        {
            return $"Money: {Amount}";
        }
    }

    public static class MoneyServices
    {
        public static Money Add(this Money money, Money moneyToAdd)
        {
            return new Money(money.Amount + moneyToAdd.Amount);
        }

        public static Money Remove(this Money money, Money moneyToRemove)
        {
            return new Money(money.Amount - moneyToRemove.Amount);
        }

        public static Money ApplyRate(this Money money, double rate)
        {
            return new Money(Convert.ToInt32(Math.Floor(money.Amount * rate)));
        }
    }
}
