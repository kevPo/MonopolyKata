using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class GoToJailLocation : ILocation
    {
        public const int JustVisitingLocationIndex = 10;

        public GoToJailLocation()
        {
            PassingAction = new NullAction();
            LandingAction = new RelocateAction(JustVisitingLocationIndex);
        }
        
        public string Name { get => "Go To Jail"; }
        public int LocationIndex { get => 30; }
        public IAction PassingAction { get; }
        public IAction LandingAction { get; }
    }
}
