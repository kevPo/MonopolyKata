using Monopoly.Actions;
using Monopoly.Locations;

namespace Monopoly
{
    public interface IGenericLocationFactory
    {
        ILocation Create(int locationIndex, IAction landingAction);
        ILocation Create(int locationIndex, IAction landingAction, IAction passingAction);
    }
}
