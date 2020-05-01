using System.Collections.Generic;

namespace Monopoly
{
    public class TurnService : ITurnService
    {
        private const int MaxNumberOfDoubles = 3;

        private readonly IMortgageService mortgageService;

        public TurnService(IMortgageService mortgageService)
        {
            this.mortgageService = mortgageService;
        }

        public TurnResult Take(int turnOrder, IPlayer player, IBoard board, IDice dice)
        {
            var initialResult = new TurnResult
            {
                TurnOrder = turnOrder,
                PlayerName = player.Name,
                Locations = new List<int>(),
                StartingLocation = player.Location,
                NumberOfDoubles = 0,
                PreTurnMortgageActivity = new List<MortgageResult>(),
                PostTurnMortgageActivity = new List<MortgageResult>()
            };

            return Take(initialResult, player, board, dice);
        }

        private TurnResult Take(TurnResult result, IPlayer player, IBoard board, IDice dice)
        {
            if (player.IsInJail)
            {
                return TakeInJailTurn(result, player, board, dice);
            }
            else
            {
                return TakeTurn(result, player, board, dice);
            }
        }

        private TurnResult TakeInJailTurn(TurnResult result, IPlayer player, IBoard board, IDice dice)
        {
            player.WithdrawMoney(MonopolyConstants.BailMoney);
            player.GetOutOfJail();

            result = Combine(result, Take(result, player, board, dice));

            return result;
        }

        private TurnResult TakeTurn(TurnResult result, IPlayer player, IBoard board, IDice dice)
        {
            result.PreTurnMortgageActivity.Add(mortgageService.ProcessMortgageTransactions(player));

            var rollResult = dice.Roll();
            var playerRolledMaxDoubles = rollResult.IsDoubles && ++result.NumberOfDoubles == MaxNumberOfDoubles;

            if (playerRolledMaxDoubles)
            {
                return MovePlayerToJail(result, player);
            }

            result = MovePlayerToLocation(result, player, board, rollResult);

            result.PostTurnMortgageActivity.Add(mortgageService.ProcessMortgageTransactions(player));

            if (rollResult.IsDoubles && !player.IsInJail)
            {
                result = Combine(result, Take(result, player, board, dice));
            }

            return result;
        }

        private static TurnResult MovePlayerToLocation(TurnResult result, IPlayer player, IBoard board, RollResult rollResult)
        {
            var moveResult = board.MoveToLocation(player.Location, rollResult.Total);

            player.MoveToLocation(moveResult.CurrentLocation.LocationIndex);
            result.Locations.Add(moveResult.CurrentLocation.LocationIndex);
            result.EndingLocation = player.Location;

            foreach (var location in moveResult.LocationHistory)
            {
                location.ProcessPassingAction(player);
            }

            moveResult.CurrentLocation.ProcessLandingAction(player);

            return result;
        }

        private static TurnResult MovePlayerToJail(TurnResult result, IPlayer player)
        {
            player.GoToJail();
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
                Locations = nextResult.Locations,
                StartingLocation = firstResult.StartingLocation,
                EndingLocation = nextResult.EndingLocation,
                PreTurnMortgageActivity = nextResult.PreTurnMortgageActivity,
                PostTurnMortgageActivity = nextResult.PostTurnMortgageActivity
            };
        }
    }
}
