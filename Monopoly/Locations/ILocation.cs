namespace Monopoly.Locations
{
    public interface ILocation
    {
        int LocationIndex { get; }

        void ProcessPassingAction(IPlayer player);
        void ProcessLandingAction(IPlayer player);
    }
}
