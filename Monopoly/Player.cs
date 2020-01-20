using System.Linq;

namespace Monopoly
{
    public class Player
    {
        public const int PassingGoReward = 200;

        public string Name { get; private set;  }
        public int Balance { get; private set; }
        public int Location { get; private set; }

        public Player(string name, int balance = 0, int location = 0)
        {
            Name = name;
            Balance = balance;
            Location = location;
        }

        public Turn TakeTurn(int turnOrder, IDice dice, Board board)
        {
            var rolled = dice.Roll();
            var result = board.MoveToLocation(Location, rolled);

            var timesPassedGo = result.LocationHistory.Count(l => l == Board.Go);
            Balance += (timesPassedGo * PassingGoReward);

            Location = result.CurrentLocation;

            return new Turn
            {
                TurnOrder = turnOrder,
                Player = Name,
                Location = Location
            };
        }
    }
}
