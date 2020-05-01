using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Locations;
using MonopolyTests.Fakes;

namespace MonopolyTests
{
    [TestClass]
    public class GameTests
    {
        private readonly FakeBoard fakeBoard;
        private readonly FakeDice fakeDice;
        private readonly FakeTurnService fakeTurnService;

        public GameTests()
        {
            fakeBoard = new FakeBoard();
            fakeDice = new FakeDice();
            fakeTurnService = new FakeTurnService();
        }

        [TestMethod]
        public void PlayerOnBeginningLocationIsAtLocation0()
        {
            var players = new[] { new Player("Horse", location: LocationConstants.BoardwalkIndex) , new Player("Car", location: LocationConstants.ParkPlaceIndex) };
            var game = new Game(players, fakeBoard, fakeDice, fakeTurnService);
            var rounds = game.Play();

            Assert.IsTrue(rounds[0].All(turn => turn.StartingLocation == 0));
        }

        [TestMethod]
        public void GameCanBeCreatedWithTwoPlayers()
        {
            var players = new[] { new Player("Horse") , new Player("Car") };

            new Game(players, fakeBoard, fakeDice, fakeTurnService);
        }

        [TestMethod]
        public void GameCannotBeCreatedWithOnePlayer()
        {
            var horse = new Player("Horse");
            var game = new Game(new[] { horse }, fakeBoard, fakeDice, fakeTurnService);

            Assert.ThrowsException<Exception>(() => game.Play());
        }

        [TestMethod]
        public void GameCannotBeCreatedWithMoreThanEightPlayers()
        {
            var game = new Game(new Player[9], fakeBoard, fakeDice, fakeTurnService);

            Assert.ThrowsException<Exception>(() => game.Play());
        }

        [TestMethod]
        public void GameCannotBeCreatedWithZeroPlayers()
        {
            var game = new Game(Enumerable.Empty<Player>().ToArray(), fakeBoard, fakeDice, fakeTurnService);

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
                var players = new[] { new Player("Horse") , new Player("Car") };
                var game = new Game(players, fakeBoard, fakeDice, fakeTurnService);
                gameRounds.Add(game.Play());
            }

            Assert.IsTrue(gameRounds.Any(r => r[0].First().PlayerName == horse.Name));
            Assert.IsTrue(gameRounds.Any(r => r[0].First().PlayerName == car.Name));
        }

        [TestMethod]
        public void PlayReturnsAGameWith20PlayedRounds()
        {
            var players = new[] { new Player("Horse") , new Player("Car") };
            var game = new Game(players, fakeBoard, fakeDice, fakeTurnService);
            var rounds = game.Play();

            Assert.AreEqual(20, rounds.Values.Count());
        }

        [TestMethod]
        public void PlayerMaintainSameTurnOrderForEveryRoundOfGame()
        {
            var players = new[] { new Player("Horse") , new Player("Car") };
            var game = new Game(players, fakeBoard, fakeDice, fakeTurnService);
            var rounds = game.Play();

            var carTurnOrder = rounds[0].Where(t => t.PlayerName == "Car").First().TurnOrder;
            var horseTurnOrder = rounds[0].Where(t => t.PlayerName == "Horse").First().TurnOrder;

            Assert.IsTrue(rounds.SelectMany(r => r.Value).Where(t => t.PlayerName == "Car").All(t => t.TurnOrder == carTurnOrder));
            Assert.IsTrue(rounds.SelectMany(r => r.Value).Where(t => t.PlayerName == "Horse").All(t => t.TurnOrder == horseTurnOrder));
        }
    }
}
