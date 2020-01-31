using Monopoly.Actions;

namespace Monopoly.Locations
{
    public class GoLocation : ILocation
    {
        private const int GoPayoutAmount = 200;
        private readonly IAction payoutAction;

        public GoLocation()
        {
            payoutAction = new PayoutAction(GoPayoutAmount);
        }

        public string Name { get => "Go"; }
        public int LocationIndex { get => 0; }
        public IAction PassingAction { get => payoutAction; }
        public IAction LandingAction { get => payoutAction; }
    }
}
