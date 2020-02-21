namespace Monopoly
{
    public interface IDice
    {
        RollResult LastRoll { get; }
        RollResult Roll();
    }
}
