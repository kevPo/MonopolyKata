using Monopoly.Locations;

namespace Monopoly.Actions
{
    public interface IPropertyAction
    {
        void ProcessAction(IPlayer player, IProperty property);
    }
}
