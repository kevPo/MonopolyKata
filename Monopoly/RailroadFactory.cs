using Monopoly.Actions;
using Monopoly.Locations;

namespace Monopoly
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
