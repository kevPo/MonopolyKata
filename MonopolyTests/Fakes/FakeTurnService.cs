using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakeTurnService : ITurnService
    {
        public TurnResult Take(int turnOrder, IPlayer player, IBoard board, IDice dice)
        {
            return new TurnResult() { TurnOrder = turnOrder, PlayerName = player.Name, StartingLocation = player.Location, EndingLocation = player.Location };
        }
    }
}
