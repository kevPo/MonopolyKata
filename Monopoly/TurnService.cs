using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class TurnService : ITurnService
    {
        public TurnResult Take(int turnOrder, IPlayer player, IBoard board, IDice dice)
        {
            var startingLocation = player.Location;
            var landedLocations = new List<int>();
            var rollResult = dice.Roll();
            var moveResult = board.MoveToLocation(player.Location, rollResult.Total);

            player.Location = moveResult.CurrentLocation.LocationIndex;
            landedLocations.Add(moveResult.CurrentLocation.LocationIndex);

            foreach (var location in moveResult.LocationHistory)
            {
                location.ProcessPassingAction(player);
            }

            moveResult.CurrentLocation.ProcessLandingAction(player);

            var result = new TurnResult
            {
                TurnOrder = turnOrder,
                PlayerName = player.Name,
                Locations = landedLocations,
                StartingLocation = startingLocation, 
                EndingLocation = player.Location
            };

            if (rollResult.IsDoubles)
            {
                result = Combine(result, Take(turnOrder, player, board, dice));
            }

            return result;
        }

        private TurnResult Combine(TurnResult firstResult, TurnResult nextResult)
        {
            return new TurnResult
            {
                TurnOrder = firstResult.TurnOrder,
                PlayerName = firstResult.PlayerName,
                Locations = firstResult.Locations.Union(nextResult.Locations).ToList(),
                StartingLocation = firstResult.StartingLocation,
                EndingLocation = nextResult.EndingLocation
            };
        }
    }
}
