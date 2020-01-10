using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class GameTests
    {
        private readonly Game game;

        public GameTests()
        {
            var players = new[] { new Player() };
            var board = new Board();

            game = new Game(board, players);
        }

        [TestMethod]
        public void PlayerOnBeginningLocationIsAtLocation0()
        {
            Assert.IsTrue(game.Players.All(p => p.Location == 0));
        }

        [TestMethod]
        public void PlayerOnBeginningLocationRolls7AndEndsOnLocation7()
        {
            var dice = new FakeDice(7);

            game.PlayRound(dice);

            Assert.AreEqual(7, game.Players.First().Location);
        }

        [TestMethod]
        public void PlayerOnLocation39Rolls6AndEndsUpOnLocation5()
        {
            var dice = new FakeDice(6);
            game.Players.First().Location = 39;

            game.PlayRound(dice);

            Assert.AreEqual(5, game.Players.First().Location);
        }

        private class FakeDice : IDice
        {
            private readonly int numberToRoll;

            public FakeDice(int numberToRoll)
            {
                this.numberToRoll = numberToRoll;
            }

            public int Roll()
            {
                return numberToRoll;
            }
        }
    }
}
