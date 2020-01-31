using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class NullLocation : ILocation
    {
        public NullLocation(string name, int locationIndex)
        {
            Name = name;
            LocationIndex = locationIndex;
            PassingAction = new NullAction();
            LandingAction = new NullAction();
        }

        public string Name { get; }
        public int LocationIndex { get; }
        public IAction PassingAction { get; }
        public IAction LandingAction { get; }
    }
}
