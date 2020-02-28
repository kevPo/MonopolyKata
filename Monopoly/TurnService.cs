namespace Monopoly
{
    public class TurnService : ITurnService
    {
        public TurnResult Take(int turnOrder, IPlayer player, IBoard board, IDice dice)
        {
            var rollResult = dice.Roll();
            var moveResult = board.MoveToLocation(player.Location, rollResult.Total);
            player.Location = moveResult.CurrentLocation.LocationIndex;

            foreach (var location in moveResult.LocationHistory)
            {
                location.ProcessPassingAction(player);
            }

            moveResult.CurrentLocation.ProcessLandingAction(player);

            return new TurnResult
            {
                TurnOrder = turnOrder,
                PlayerName = player.Name,
                Location = player.Location
            };
        }
    }
}
