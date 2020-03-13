namespace Monopoly
{
    public interface IMortgageService
    {
        MortgageResult ProcessMortgageTransactions(IPlayer player);
    }
}
