using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class NullLocation : Location
    {
        public NullLocation(string name, int locationIndex)
            :base(name, locationIndex, new NullAction(), new NullAction())
        {
        }
    }
}
