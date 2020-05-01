using Monopoly.Actions;

namespace Monopoly.Locations.Factories
{
    public interface IGenericLocationFactory
    {
        ILocation Create(int locationIndex, IAction landingAction);
        ILocation Create(int locationIndex, IAction landingAction, IAction passingAction);
    }
}
