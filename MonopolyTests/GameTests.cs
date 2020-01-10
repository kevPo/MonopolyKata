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
        private readonly Game game;
        private readonly Board board;
        private readonly FakeDice dice;
        private readonly IEnumerable<Player> players;

        public GameTests()
        {
            players = new[] { new Player("Horse"), new Player("Car") };

            board = new Board();
            dice = new FakeDice();
            game = new Game(board, dice, players.ToArray());
        }

        [TestMethod]
        public void PlayerOnBeginningLocationIsAtLocation0()
        {
            Assert.IsTrue(players.All(p => p.Location == 0));
        }

        [TestMethod]
        public void PlayerOnBeginningLocationRolls7AndEndsOnLocation7()
        {
            dice.LoadRoll(7);
            dice.LoadRoll(7);

            game.Play(1);

            Assert.IsTrue(players.All(p => p.Location == 7));
        }

        [TestMethod]
        public void PlayerOnLocation39Rolls6AndEndsUpOnLocation5()
        {
            dice.LoadRoll(6);
            dice.LoadRoll(6);
            players.ToList().ForEach(p => p.Location = 39);

            game.Play(1);

            Assert.IsTrue(players.All(p => p.Location == 5));
        }

        [TestMethod]
        public void GameCanBeCreatedWithTwoPlayers()
        {
            var players = new[] { new Player("Horse"), new Player("Car") };

            new Game(board, dice, players);
        }

        [TestMethod]
        public void GameCannotBeCreatedWithOnePlayer()
        {
            var horse = new Player("Horse");
            var game = new Game(board, dice, new[] { horse });

            Assert.ThrowsException<Exception>(() => game.Play(1));
        }

        [TestMethod]
        public void GameCannotBeCreatedWithMoreThanEightPlayers()
        {
            var game = new Game(board, dice, new Player[9]);

            Assert.ThrowsException<Exception>(() => game.Play(1));
        }

        [TestMethod]
        public void GameCannotBeCreatedWithZeroPlayers()
        {
            var game = new Game(board, dice, Enumerable.Empty<Player>().ToArray());

            Assert.ThrowsException<Exception>(() => game.Play(1));
        }

        [TestMethod]
        public void TheOrderOfPlayersIsRandomPer100Games()
        {
            var games = new List<Game>();
            var horse = new Player("horse");
            var car = new Player("car");

            for (var i = 0; i < 100; i++)
            {
                games.Add(new Game(board, dice, new[] { horse, car }));
            }

            Assert.IsTrue(games.Any(g => g.GetPlayerOrder().First() == horse.Name));
            Assert.IsTrue(games.Any(g => g.GetPlayerOrder().First() == car.Name));
        }
    }
}
