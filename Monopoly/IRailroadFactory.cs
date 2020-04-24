using Monopoly.Locations;

namespace Monopoly
{
    public interface IRailroadFactory
    {
        ILocation Create(int locationIndex);
    }
}
