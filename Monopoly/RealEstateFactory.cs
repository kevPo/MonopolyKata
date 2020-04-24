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

        public ILocation Create(int locationIndex)
        {
            var propertyGroup = LocationConstants.PropertyGroupDictionary[locationIndex];
            var cost = LocationConstants.PropertyCostDictionary[locationIndex];
            var rent = LocationConstants.PropertyRentDictionary[locationIndex];
            return new Property(locationIndex, propertyGroup, realEstateRentAction, cost, rent);
        }
    }
}
