using Monopoly.Locations;

namespace Monopoly
{
    public interface IMortgageBroker
    {
        bool TakeOutMortgage(IPlayer player, IProperty property);
        bool PayOffMortgage(IPlayer player, IProperty property);
    }
}
