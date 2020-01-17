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
        private readonly IDictionary<int, Player> players;

        public Game(Board board, IDice dice, IEnumerable<Player> players)
        {
            this.board = board;
            this.dice = dice;
            this.players = ShufflePlayers(players);

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
            ValidateGameHasCorrectNumberOfPlayers();

            for (var round = 0; round < NumberOfRounds; round++)
            {
                PlayRound(round);
            }

            return this;
        }

        private void ValidateGameHasCorrectNumberOfPlayers()
        {
            if (players.Count() < 2 || players.Count() > 8)
            {
                throw new Exception();
            }
        }

        private void PlayRound(int round)
        {
            var turns = new List<Turn>();

            for (var i = 0; i < players.Count(); i++)
            {
                turns.Add(players[i].TakeTurn(i, dice, board));
            }

            Rounds.Add(round, turns);
        }
    }
}
