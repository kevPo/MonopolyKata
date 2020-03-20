namespace Monopoly
{
    public interface IPlayer
    {
        string Name { get; }
        int Location { get; }
        Money Balance { get; }
        bool IsInJail { get; }

        bool HasAvailableFunds(Money amount);
        bool DepositMoney(Money amount);
        bool WithdrawMoney(Money amount);
        void MoveToLocation(int location);
        void GoToJail();
        void GetOutOfJail();
    }
}
