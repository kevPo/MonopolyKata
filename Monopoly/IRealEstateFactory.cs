using Monopoly.Locations;

namespace Monopoly
{
    public interface IRealEstateFactory
    {
        ILocation Create(int locationIndex);
    }
}
