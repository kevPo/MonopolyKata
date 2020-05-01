using Monopoly.Actions;

namespace Monopoly.Locations.Factories
{
    public class UtilityFactory : IUtilityFactory
    {
        private readonly UtilityRentAction utilityRentAction;

        public UtilityFactory(IBoard board, IDice dice)
        {
            utilityRentAction = new UtilityRentAction(board, dice);
        }

        public ILocation Create(int locationIndex)
        {
            return new Property(locationIndex, LocationConstants.UtilityGroup, utilityRentAction, LocationConstants.UtilityCost);
        }
    }
}
