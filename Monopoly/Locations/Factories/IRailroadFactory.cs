namespace Monopoly.Locations.Factories
{
    public interface IRailroadFactory
    {
        ILocation Create(int locationIndex);
    }
}
