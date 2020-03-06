namespace Monopoly.Locations
{
    public interface IProperty : ILocation
    {
        PropertyGroup PropertyGroup { get; }
        IPlayer Owner { get; }
        Money Cost { get; }
        Money Rent { get; }
        bool IsMortgaged { get; }

        bool IsUnowned();
        void TransitionOwnership(IPlayer player);
        void MortgageProperty();
    }
}
