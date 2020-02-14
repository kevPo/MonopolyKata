namespace Monopoly
{
    public struct Money
    {
        public Money(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; }
    }

    //public class Money
    //{
    //    public Money(int amount)
    //    {
    //        Amount = amount;
    //    }

    //    public int Amount { get; }

    //    public override bool Equals(object obj)
    //    {
    //        if (obj is Money)
    //        {
    //            return (obj as Money).Amount == Amount;
    //        }

    //        return false;
    //    }

    //    public override int GetHashCode()
    //    {
    //        return base.GetHashCode();
    //    }
    //}

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
    }
}
