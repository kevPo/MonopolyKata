using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class NullLocation : Location
    {
        public NullLocation(int locationIndex)
            : base(locationIndex, new NullAction(), new NullAction())
        {
        }
    }
}
