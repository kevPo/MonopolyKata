namespace Monopoly
{
    public interface ILocation
    {
        string Name { get; }
        int LocationIndex { get; }
        IAction PassingAction { get; }
        IAction LandingAction { get; }
    }

}
