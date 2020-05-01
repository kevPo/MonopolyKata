namespace Monopoly.Locations.Factories
{
    public interface IUtilityFactory
    {
        ILocation Create(int locationIndex);
    }
}
