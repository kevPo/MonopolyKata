namespace Monopoly.Locations
{
    public interface ILocation
    {
        int LocationIndex { get; }
        IPlayer Owner { get; set; }

        void ProcessPassingAction(IPlayer player);
        void ProcessLandingAction(IPlayer player);
    }
}
