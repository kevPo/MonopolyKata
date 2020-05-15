namespace Monopoly.Locations.Factories
{
    public interface ICardLocationFactory
    {
        ILocation CreateChanceLocation(int locationIndex);
        ILocation CreateCommunityChestLocation(int locationIndex);
    }
}
