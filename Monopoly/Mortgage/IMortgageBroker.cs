using Monopoly.Locations;

namespace Monopoly.Mortgage
{
    public interface IMortgageBroker
    {
        bool TakeOutMortgage(IPlayer player, IProperty property);
        bool PayOffMortgage(IPlayer player, IProperty property);
    }
}
