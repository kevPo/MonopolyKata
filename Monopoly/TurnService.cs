using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;

namespace Monopoly
{
    public class TurnService : ITurnService
    {
        private const int DoublesToJustVisiting = 3;

        public TurnResult Take(int turnOrder, IPlayer player, IBoard board, IDice dice)
        {
            return Take(turnOrder, player, board, dice, 0);
        }

        private TurnResult Take(int turnOrder, IPlayer player, IBoard board, IDice dice, int numberOfDoubles)
        {
            var startingLocation = player.Location;
            var landedLocations = new List<int>();
            var rollResult = dice.Roll();

            if (rollResult.IsDoubles)
            {
                if (++numberOfDoubles == DoublesToJustVisiting)
                {
                    player.Location = LocationConstants.JustVisitingIndex;
                    landedLocations.Add(player.Location);

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
                result = Combine(result, Take(turnOrder, player, board, dice, numberOfDoubles));
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
