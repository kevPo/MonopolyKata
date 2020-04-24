using Monopoly.Locations;

namespace Monopoly
{
    public interface IRealEstateFactory
    {
        ILocation Create(int locationIndex, PropertyGroup propertyGroup, Money cost, Money rent);
    }
}
