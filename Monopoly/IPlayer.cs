namespace Monopoly
{
    public interface IPlayer
    {
        string Name { get; }
        int Location { get; set; }
        Money Balance { get; }
        bool IsInJail { get; set; }

        bool HasAvailableFunds(Money amount);
        bool DepositMoney(Money amount);
        bool WithdrawMoney(Money amount);
    }
}
