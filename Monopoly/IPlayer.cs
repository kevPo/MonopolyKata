namespace Monopoly
{
    public interface IPlayer
    {
        string Name { get; }
        int Location { get; set; }
        // TODO: refactor out this setter into add/remove methods
        Money Balance { get; set; }
    }
}
