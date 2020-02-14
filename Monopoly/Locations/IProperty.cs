namespace Monopoly.Locations
{
    public interface IProperty : ILocation
    {
        IPlayer Owner { get; }
        Money Cost { get; }
        Money Rent { get; }

        // TODO: move to player
        void PurchaseProperty(IPlayer player);
    }
}
