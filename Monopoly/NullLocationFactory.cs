using Monopoly.Locations;

namespace Monopoly
{
    public class NullLocationFactory : INullLocationFactory
    {
        public ILocation Create(int locationIndex)
        {
            return new NullLocation(locationIndex);
        }
    }
}
