namespace Monopoly
{
    public interface ITurnService
    {
        TurnResult Take(int turnOrder, IPlayer player, IBoard board, IDice dice);
    }
}
