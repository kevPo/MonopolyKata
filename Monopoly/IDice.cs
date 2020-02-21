namespace Monopoly
{
    public interface IDice
    {
        int LastRoll { get; }
        int Roll();
    }
}
