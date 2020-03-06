using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class GameTests
    {
        private readonly Board board;
        private readonly FakeDice dice;
        private readonly IEnumerable<Player> players;
        private readonly ITurnService turnService;
        private Game game;

        public GameTests()
        {
            players = new[] { new Player("Horse"), new Player("Car") };

            dice = new FakeDice();
            board = new Board(dice);
            turnService = new TurnService();
            game = new Game(players.ToArray(), board, dice, turnService);
        }

        [TestMethod]
        public void PlayerOnBeginningLocationIsAtLocation0()
        {
            var rounds = game.Play();

            Assert.IsTrue(rounds[0].All(turn => turn.StartingLocation == 0));
        }

        [TestMethod]
        public void PlayerOnBeginningLocationRolls7AndEndsOnLocation7()
        {
            dice.LoadRoll(3, 4);
            dice.LoadRoll(3, 4);

            var rounds = game.Play();

            Assert.IsTrue(rounds[0].All(turn => turn.EndingLocation == 7));
        }

        [TestMethod]
        public void PlayerOnLocation39Rolls6AndEndsUpOnLocation5()
        {
            dice.LoadRoll(2, 37);
            dice.LoadRoll(2, 37);
            dice.LoadRoll(2, 4);
            dice.LoadRoll(2, 4);

            var rounds = game.Play();

            Assert.IsTrue(rounds[1].All(turn => turn.EndingLocation == 5));
        }

        [TestMethod]
        public void GameCanBeCreatedWithTwoPlayers()
        {
            var players = new[] { new Player("Horse") , new Player("Car") };

            new Game(players, board, dice, turnService);
        }

        [TestMethod]
        public void GameCannotBeCreatedWithOnePlayer()
        {
            var horse = new Player("Horse");
            var game = new Game(new[] { horse }, board, dice, turnService);

            Assert.ThrowsException<Exception>(() => game.Play());
        }

        [TestMethod]
        public void GameCannotBeCreatedWithMoreThanEightPlayers()
        {
            var game = new Game(new Player[9], board, dice, turnService);

            Assert.ThrowsException<Exception>(() => game.Play());
        }

        [TestMethod]
        public void GameCannotBeCreatedWithZeroPlayers()
        {
            var game = new Game(Enumerable.Empty<Player>().ToArray(), board, dice, turnService);

            Assert.ThrowsException<Exception>(() => game.Play());
        }

        [TestMethod]
        public void TheOrderOfPlayersIsRandomPer100Games()
        {
            var gameRounds = new List<IDictionary<int, IEnumerable<TurnResult>>>();
            var horse = new Player("Horse");
            var car = new Player("Car");

            for (var i = 0; i < 100; i++)
            {
                var game = new Game(new[] { horse, car }, board, dice, turnService);
                gameRounds.Add(game.Play());
            }

            Assert.IsTrue(gameRounds.Any(r => r[0].First().PlayerName == horse.Name));
            Assert.IsTrue(gameRounds.Any(r => r[0].First().PlayerName == car.Name));
        }

        [TestMethod]
        public void PlayReturnsAGameWith20PlayedRounds()
        {
            var rounds = game.Play();

            Assert.AreEqual(20, rounds.Values.Count());
        }

        [TestMethod]
        public void PlayerMaintainSameTurnOrderForEveryRoundOfGame()
        {
            var rounds = game.Play();

            var carTurnOrder = rounds[0].Where(t => t.PlayerName == "Car").First().TurnOrder;
            var horseTurnOrder = rounds[0].Where(t => t.PlayerName == "Horse").First().TurnOrder;

            Assert.IsTrue(rounds.SelectMany(r => r.Value).Where(t => t.PlayerName == "Car").All(t => t.TurnOrder == carTurnOrder));
            Assert.IsTrue(rounds.SelectMany(r => r.Value).Where(t => t.PlayerName == "Horse").All(t => t.TurnOrder == horseTurnOrder));
        }
    }
}
