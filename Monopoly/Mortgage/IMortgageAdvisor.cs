using Monopoly.Locations;

namespace Monopoly.Mortgage
{
    public interface IMortgageAdvisor
    {
        bool PlayerShouldMortgageProperty(IPlayer player, IProperty property);
        bool PlayerShouldPayOffMortgage(IPlayer player, IProperty property);
    }
}
