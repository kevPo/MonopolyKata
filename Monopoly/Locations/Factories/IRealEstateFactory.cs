namespace Monopoly.Locations.Factories
{
    public interface IRealEstateFactory
    {
        ILocation Create(int locationIndex);
    }
}
