namespace Monopoly.Locations
{
    public interface IProperty : ILocation
    {
        IPlayer Owner { get; }
        int Cost { get; }
        int Rent { get; }

        void PurchaseProperty(IPlayer player);
    }
}
