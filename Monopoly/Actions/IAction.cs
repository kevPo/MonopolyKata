using Monopoly.Locations;

namespace Monopoly.Actions
{
    public interface IAction
    {
        void ProcessAction(IPlayer player, ILocation location);
    }
}
