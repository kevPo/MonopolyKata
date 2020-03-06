using System.Linq;
using System.Collections.Generic;
using Monopoly.Locations;

namespace Monopoly
{
    public class TurnService : ITurnService
    {
        private const int MaxNumberOfDoubles = 3;

        public TurnResult Take(int turnOrder, IPlayer player, IBoard board, IDice dice)
        {
            var initialResult = new TurnResult
            {
                TurnOrder = turnOrder,
                PlayerName = player.Name,
                Locations = new List<int>(),
                StartingLocation = player.Location,
                NumberOfDoubles = 0
            };

            return Take(initialResult, player, board, dice);
        }

        private static TurnResult Take(TurnResult result, IPlayer player, IBoard board, IDice dice)
        {
            var rollResult = dice.Roll();
            var playerRolledMaxDoubles = rollResult.IsDoubles && ++result.NumberOfDoubles == MaxNumberOfDoubles;

            if (playerRolledMaxDoubles)
            {
                return MovePlayerToJustVisiting(result, player);
            }

            result = MovePlayerToLocation(result, player, board, rollResult);

            if (rollResult.IsDoubles)
            {
                result = Combine(result, Take(result, player, board, dice));
            }

            return result;
        }

        private static TurnResult MovePlayerToLocation(TurnResult result, IPlayer player, IBoard board, RollResult rollResult)
        {
            var moveResult = board.MoveToLocation(player.Location, rollResult.Total);

            player.Location = moveResult.CurrentLocation.LocationIndex;
            result.Locations.Add(moveResult.CurrentLocation.LocationIndex);
            result.EndingLocation = player.Location;

            foreach (var location in moveResult.LocationHistory)
            {
                location.ProcessPassingAction(player);
            }

            moveResult.CurrentLocation.ProcessLandingAction(player);

            return result;
        }

        private static TurnResult MovePlayerToJustVisiting(TurnResult result, IPlayer player)
        {
            player.Location = LocationConstants.JustVisitingIndex;
            result.Locations.Add(player.Location);
            result.EndingLocation = player.Location;

            return result;
        }

        private static TurnResult Combine(TurnResult firstResult, TurnResult nextResult)
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
