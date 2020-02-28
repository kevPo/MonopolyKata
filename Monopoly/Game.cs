﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly
{
    public class Game
    {
        private const int NumberOfRounds = 20;
        private const int MinimumPlayers = 2;
        private const int MaximumPlayers = 8;

        private readonly IBoard board;
        private readonly IDice dice;
        private readonly ITurnService turnService;
        private readonly IDictionary<int, Player> playerOrder;

        public Game(IEnumerable<Player> players, IBoard board, IDice dice, ITurnService turnService)
        {
            this.board = board;
            this.dice = dice;
            this.turnService = turnService;
            this.playerOrder = ShufflePlayers(players);
        }

        private IDictionary<int, Player> ShufflePlayers(IEnumerable<Player> players)
        {
            var orderedPlayers = players.OrderBy(p => Guid.NewGuid());
            var playerOrder = 0;

            return orderedPlayers.ToDictionary(p => playerOrder++, p => p);
        }

        public IDictionary<int, IEnumerable<TurnResult>> Play()
        {
            ValidateGameHasCorrectNumberOfPlayers();
            var rounds = new Dictionary<int, IEnumerable<TurnResult>>();

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

        private IEnumerable<TurnResult> PlayRound()
        {
            var turns = new List<TurnResult>();

            for (var i = 0; i < playerOrder.Count(); i++)
            {
                turns.Add(turnService.Take(i, playerOrder[i], board, dice));
            }

            return turns;
        }
    }
}
