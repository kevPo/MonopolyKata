namespace Monopoly
{
    public class Player
    {
        public string Name { get; set;  }

        public Turn TakeTurn(int turnOrder, IDice dice, Board board)
        {
            var rolled = dice.Roll();
            var newLocation = board.MovePlayer(Name, rolled);

            return new Turn
            {
                TurnOrder = turnOrder,
                Player = Name,
                Location = newLocation
            };
        }
    }
}
