using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Game
    {
        private readonly Board board;
        private readonly IDice dice;
        private readonly IOrderedEnumerable<Player> players;

        public Game(Board board, IDice dice, IEnumerable<Player> players)
        {
            this.board = board;
            this.dice = dice;
            this.players = ShufflePlayers(players);
        }

        private IOrderedEnumerable<Player> ShufflePlayers(IEnumerable<Player> players)
        {
            return players.OrderBy(p => Guid.NewGuid());
        }

        public IEnumerable<string> GetPlayerOrder()
        {
            return players.Select(p => p.Name);
        }

        public void Play(int rounds)
        {
            if (players.Count() < 2 || players.Count() > 8)
            {
                throw new Exception();
            }

            for (var i = 0; i < rounds; i++)
            {
                PlayRound();
            }
        }

        private void PlayRound()
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
