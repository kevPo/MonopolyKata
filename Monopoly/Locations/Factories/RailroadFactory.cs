using Monopoly.Actions;

namespace Monopoly.Locations.Factories
{
    public class RailroadFactory : IRailroadFactory
    {
        private readonly RailroadRentAction railroadRentAction;

        public RailroadFactory(IBoard board)
        {
            railroadRentAction = new RailroadRentAction(board);
        }

        public ILocation Create(int locationIndex)
        {
            return new Property(locationIndex, LocationConstants.RailroadGroup, railroadRentAction, LocationConstants.RailroadCost);
        }
    }
}
