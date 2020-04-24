using Monopoly.Actions;
using Monopoly.Locations;

namespace Monopoly
{
    public class RealEstateFactory : IRealEstateFactory
    {
        private readonly RealEstateRentAction realEstateRentAction;

        public RealEstateFactory(IBoard board)
        {
            realEstateRentAction = new RealEstateRentAction(board);
        }

        public ILocation Create(int locationIndex, PropertyGroup propertyGroup, Money cost, Money rent)
        {
            return new Property(locationIndex, propertyGroup, realEstateRentAction, cost, rent);
        }
    }
}
