namespace Monopoly
{
    public interface IPlayer
    {
        string Name { get; }
        int Location { get; set; }
        Money Balance { get; }

        bool HasAvailableFunds(Money amount);
        bool DepositMoney(Money amount);
        bool WithdrawMoney(Money amount);
    }
}
