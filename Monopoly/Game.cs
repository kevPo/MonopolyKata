using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Game
    {
        private const int NumberOfRounds = 20;
        private const int MinimumPlayers = 2;
        private const int MaximumPlayers = 8;

        private readonly Board board;
        private readonly IDice dice;
        private readonly IDictionary<int, Player> playerOrder;

        public Game(Board board, IDice dice, IEnumerable<Player> players)
        {
            this.board = board;
            this.dice = dice;
            this.playerOrder = ShufflePlayers(players);
        }

        private IDictionary<int, Player> ShufflePlayers(IEnumerable<Player> players)
        {
            var orderedPlayers = players.OrderBy(p => Guid.NewGuid());
            var playerOrder = 0;

            return orderedPlayers.ToDictionary(p => playerOrder++, p => p);
        }

        public IDictionary<int, IEnumerable<Turn>> Play()
        {
            ValidateGameHasCorrectNumberOfPlayers();
            var rounds = new Dictionary<int, IEnumerable<Turn>>();

            for (var round = 0; round < NumberOfRounds; round++)
            {
                rounds.Add(round, PlayRound());
            }

            return rounds;
        }

        private void ValidateGameHasCorrectNumberOfPlayers()
        {
            if (playerOrder.Count() < MinimumPlayers || playerOrder.Count() > MaximumPlayers)
            {
                throw new Exception();
            }
        }

        private IEnumerable<Turn> PlayRound()
        {
            var turns = new List<Turn>();

            for (var i = 0; i < playerOrder.Count(); i++)
            {
                turns.Add(playerOrder[i].TakeTurn(i, dice, board));
            }

            return turns;
        }
    }
}
