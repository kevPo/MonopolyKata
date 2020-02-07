namespace Monopoly
{
    public interface IPlayer
    {
        string Name { get; }
        int Location { get; set; }
        int Balance { get; set; }
    }
}
