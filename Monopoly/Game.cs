using System.Linq;

namespace Monopoly
{
    public class Game
    {
        private readonly Board board;
        private readonly Player[] players;

        public Game(Board board, Player[] players)
        {
            this.board = board;
            this.players = players;
        }

        public Player[] Players
        {
            get
            {
                return players;
            }
        }

        public void PlayRound(IDice dice)
        {
            players.ToList().ForEach(p => TakeTurn(p, dice));
        }

        private void TakeTurn(Player player, IDice dice)
        {
            var rolled = dice.Roll();
            player.Location = board.CalculateNewLocation(player.Location, rolled);
        }
    }
}
