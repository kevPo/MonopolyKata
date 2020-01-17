using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Game
    {
        private const int NumberOfRounds = 20;

        public IDictionary<int, IEnumerable<Turn>> Rounds { get; private set; }

        private readonly Board board;
        private readonly IDice dice;
        private readonly IDictionary<int, Player> playerOrder;

        public Game(Board board, IDice dice, IEnumerable<Player> players)
        {
            this.board = board;
            this.dice = dice;
            this.playerOrder = ShufflePlayers(players);

            Rounds = new Dictionary<int, IEnumerable<Turn>>();
        }

        private IDictionary<int, Player> ShufflePlayers(IEnumerable<Player> players)
        {
            var orderedPlayers = players.OrderBy(p => Guid.NewGuid());
            var playerOrder = 0;

            return orderedPlayers.ToDictionary(p => playerOrder++, p => p);
        }

        public Game Play()
        {
            if (playerOrder.Count() < 2 || playerOrder.Count() > 8)
            {
                throw new Exception();
            }

            for (var round = 0; round < NumberOfRounds; round++)
            {
                PlayRound(round);
            }

            return this;
        }

        private void PlayRound(int round)
        {
            var turns = new List<Turn>();

            for (var i = 0; i < playerOrder.Count(); i++)
            {
                turns.Add(TakeTurn(playerOrder[i], i));
            }

            Rounds.Add(round, turns);
        }

        private Turn TakeTurn(Player player, int turnOrder)
        {
            var rolled = dice.Roll();
            player.Location = board.CalculateNewLocation(player.Location, rolled);

            return new Turn(turnOrder, new Player { Name = player.Name, Location = player.Location });
        }
    }
}
