namespace Monopoly.Locations
{
    public interface IProperty : ILocation
    {
        IPlayer Owner { get; }
        Money Cost { get; }
        Money Rent { get; }

        bool IsUnowned();
        void TransitionOwnership(IPlayer player);
    }
}
