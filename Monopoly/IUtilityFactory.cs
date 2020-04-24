using Monopoly.Locations;

namespace Monopoly
{
    public interface IUtilityFactory
    {
        ILocation Create(int locationIndex);
    }
}
