namespace Monopoly.Locations.Factories
{
    public class NullLocationFactory : INullLocationFactory
    {
        public ILocation Create(int locationIndex)
        {
            return new NullLocation(locationIndex);
        }
    }
}
