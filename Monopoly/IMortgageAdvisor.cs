using Monopoly.Locations;

namespace Monopoly
{
    public interface IMortgageAdvisor
    {
        bool PlayerShouldMortgageProperty(IPlayer player, IProperty property);
    }
}
