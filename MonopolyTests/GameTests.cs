using System;
using System.Linq;
using System.Collections.Generic;
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
        private Game game;

        public GameTests()
        {
            players = new[] { new Player { Name = "Horse" }, new Player { Name = "Car" } };

            board = new Board();
            dice = new FakeDice();
            game = new Game(board, dice, players.ToArray());
        }

        [TestMethod]
        public void PlayerOnBeginningLocationIsAtLocation0()
        {
            dice.LoadRoll(0);
            dice.LoadRoll(0);

            game = game.Play();

            Assert.IsTrue(game.Rounds[0].All(turn => turn.Location == 0));
        }

        [TestMethod]
        public void PlayerOnBeginningLocationRolls7AndEndsOnLocation7()
        {
            dice.LoadRoll(7);
            dice.LoadRoll(7);

            game = game.Play();

            Assert.IsTrue(game.Rounds[0].All(turn => turn.Location == 7));
        }

        [TestMethod]
        public void PlayerOnLocation39Rolls6AndEndsUpOnLocation5()
        {
            dice.LoadRoll(39);
            dice.LoadRoll(39);
            dice.LoadRoll(6);
            dice.LoadRoll(6);

            game = game.Play();

            Assert.IsTrue(game.Rounds[1].All(turn => turn.Location == 5));
        }

        [TestMethod]
        public void GameCanBeCreatedWithTwoPlayers()
        {
            var players = new[] { new Player { Name = "Horse" }, new Player { Name = "Car" } };

            new Game(board, dice, players);
        }

        [TestMethod]
        public void GameCannotBeCreatedWithOnePlayer()
        {
            var horse = new Player { Name = "Horse" };
            var game = new Game(board, dice, new[] { horse });

            Assert.ThrowsException<Exception>(() => game.Play());
        }

        [TestMethod]
        public void GameCannotBeCreatedWithMoreThanEightPlayers()
        {
            var game = new Game(board, dice, new Player[9]);

            Assert.ThrowsException<Exception>(() => game.Play());
        }

        [TestMethod]
        public void GameCannotBeCreatedWithZeroPlayers()
        {
            var game = new Game(board, dice, Enumerable.Empty<Player>().ToArray());

            Assert.ThrowsException<Exception>(() => game.Play());
        }

        [TestMethod]
        public void TheOrderOfPlayersIsRandomPer100Games()
        {
            var games = new List<Game>();
            var horse = new Player { Name = "Horse" };
            var car = new Player { Name = "Car" };

            for (var i = 0; i < 100; i++)
            {
                var game = new Game(board, dice, new[] { horse, car });
                games.Add(game.Play());
            }

            Assert.IsTrue(games.Any(g => g.Rounds[0].First().Player == horse.Name));
            Assert.IsTrue(games.Any(g => g.Rounds[0].First().Player == car.Name));
        }

        [TestMethod]
        public void PlayReturnsAGameWith20PlayedRounds()
        {
            game = game.Play();

            Assert.AreEqual(20, game.Rounds.Count());
        }

        [TestMethod]
        public void PlayerMaintainSameTurnOrderForEveryRoundOfGame()
        {
            game = game.Play();

            var carTurnOrder = game.Rounds[0].Where(t => t.Player == "Car").First().TurnOrder;
            var horseTurnOrder = game.Rounds[0].Where(t => t.Player == "Horse").First().TurnOrder;

            Assert.IsTrue(game.Rounds.SelectMany(r => r.Value).Where(t => t.Player == "Car").All(t => t.TurnOrder == carTurnOrder));
            Assert.IsTrue(game.Rounds.SelectMany(r => r.Value).Where(t => t.Player == "Horse").All(t => t.TurnOrder == horseTurnOrder));
        }
    }
}
