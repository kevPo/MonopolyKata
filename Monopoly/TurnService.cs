using System.Collections.Generic;

namespace Monopoly
{
    public class TurnService : ITurnService
    {
        public TurnResult Take(int turnOrder, IPlayer player, IBoard board, IDice dice)
        {
            var startingLocation = player.Location;
            return Take(turnOrder, player, board, dice, startingLocation, new List<int>());
        }

        private TurnResult Take(int turnOrder, IPlayer player, IBoard board, IDice dice, int startingLocation, IList<int> landedLocations)
        {
            var rollResult = dice.Roll();
            var moveResult = board.MoveToLocation(player.Location, rollResult.Total);

            player.Location = moveResult.CurrentLocation.LocationIndex;
            landedLocations.Add(moveResult.CurrentLocation.LocationIndex);

            foreach (var location in moveResult.LocationHistory)
            {
                location.ProcessPassingAction(player);
            }

            moveResult.CurrentLocation.ProcessLandingAction(player);

            if (rollResult.IsDoubles)
            {
                return Take(turnOrder, player, board, dice, startingLocation, landedLocations);
            }

            return new TurnResult
            {
                TurnOrder = turnOrder,
                PlayerName = player.Name,
                Locations = landedLocations,
                StartingLocation = startingLocation,
                EndingLocation = player.Location
            };
        }
    }
}
