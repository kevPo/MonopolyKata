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
        private Game game;

        public GameTests()
        {
            players = new[] { new Player("Horse"), new Player("Car") };

            dice = new FakeDice();
            board = new Board(dice);
            game = new Game(board, dice, players.ToArray());
        }

        [TestMethod]
        public void PlayerOnBeginningLocationIsAtLocation0()
        {
            dice.LoadRoll(0, 0);
            dice.LoadRoll(0, 0);

            var rounds = game.Play();

            Assert.IsTrue(rounds[0].All(turn => turn.Location == 0));
        }

        [TestMethod]
        public void PlayerOnBeginningLocationRolls7AndEndsOnLocation7()
        {
            dice.LoadRoll(3, 4);
            dice.LoadRoll(3, 4);

            var rounds = game.Play();

            Assert.IsTrue(rounds[0].All(turn => turn.Location == 7));
        }

        [TestMethod]
        public void PlayerOnLocation39Rolls6AndEndsUpOnLocation5()
        {
            dice.LoadRoll(2, 37);
            dice.LoadRoll(2, 37);
            dice.LoadRoll(2, 4);
            dice.LoadRoll(2, 4);

            var rounds = game.Play();

            Assert.IsTrue(rounds[1].All(turn => turn.Location == 5));
        }

        [TestMethod]
        public void GameCanBeCreatedWithTwoPlayers()
        {
            var players = new[] { new Player("Horse") , new Player("Car") };

            new Game(board, dice, players);
        }

        [TestMethod]
        public void GameCannotBeCreatedWithOnePlayer()
        {
            var horse = new Player("Horse");
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
            var gameRounds = new List<IDictionary<int, IEnumerable<Turn>>>();
            var horse = new Player("Horse");
            var car = new Player("Car");

            for (var i = 0; i < 100; i++)
            {
                var game = new Game(board, dice, new[] { horse, car });
                gameRounds.Add(game.Play());
            }

            Assert.IsTrue(gameRounds.Any(r => r[0].First().Player == horse.Name));
            Assert.IsTrue(gameRounds.Any(r => r[0].First().Player == car.Name));
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

            var carTurnOrder = rounds[0].Where(t => t.Player == "Car").First().TurnOrder;
            var horseTurnOrder = rounds[0].Where(t => t.Player == "Horse").First().TurnOrder;

            Assert.IsTrue(rounds.SelectMany(r => r.Value).Where(t => t.Player == "Car").All(t => t.TurnOrder == carTurnOrder));
            Assert.IsTrue(rounds.SelectMany(r => r.Value).Where(t => t.Player == "Horse").All(t => t.TurnOrder == horseTurnOrder));
        }
    }
}
