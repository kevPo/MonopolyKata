namespace Monopoly.Mortgage
{
    public interface IMortgageService
    {
        MortgageResult ProcessMortgageTransactions(IPlayer player);
    }
}
