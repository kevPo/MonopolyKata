using Monopoly.Actions;

namespace Monopoly.Locations.Factories
{
    public class GenericLocationFactory : IGenericLocationFactory
    {
        public ILocation Create(int locationIndex, IAction landingAction)
        {
            return new Location(locationIndex, landingAction, new NullAction());
        }

        public ILocation Create(int locationIndex, IAction landingAction, IAction passingAction)
        {
            return new Location(locationIndex, landingAction, passingAction);
        }
    }
}
