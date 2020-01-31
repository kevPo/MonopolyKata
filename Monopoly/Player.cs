namespace Monopoly
{
    public class Player : IPlayer
    {
        public const int PassingGoReward = 200;

        public string Name { get; set;  }
        public int Balance { get; set; }
        public int Location { get; set; }

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
            Location = result.CurrentLocation.LocationIndex;

            foreach (var location in result.LocationHistory)
            {
                location.ProcessPassingAction(this);
            }

            result.CurrentLocation.ProcessLandingAction(this);

            return new Turn
            {
                TurnOrder = turnOrder,
                Player = Name,
                Location = Location
            };
        }
    }
}
