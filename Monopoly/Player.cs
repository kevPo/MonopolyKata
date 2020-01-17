namespace Monopoly
{
    public class Player
    {
        public string Name { get; private set;  }
        public int Balance { get; private set; }

        public Player(string name, int balance = 0)
        {
            Name = name;
            Balance = balance;
        }

        public Turn TakeTurn(int turnOrder, IDice dice, Board board)
        {
            var rolled = dice.Roll();
            var newLocation = board.MovePlayer(Name, rolled);

            if (newLocation == Board.Go)
            {
                Balance += 200;
            }

            return new Turn
            {
                TurnOrder = turnOrder,
                Player = Name,
                Location = newLocation
            };
        }
    }
}
