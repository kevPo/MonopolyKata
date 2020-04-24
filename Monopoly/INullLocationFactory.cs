using Monopoly.Locations;

namespace Monopoly
{
    public interface INullLocationFactory
    {
        ILocation Create(int locationIndex);
    }
}
