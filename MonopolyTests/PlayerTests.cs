using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void TakeTurnReturnsNewTurnWithNewLocationFromBoard()
        {
            var player = new Player { Name = "Horse" };
            var fakeDice = new FakeDice();
            var turnOrder = 0;
            var board = new Board();
            var newLocation = 10;
            fakeDice.LoadRoll(10);

            var turn = player.TakeTurn(turnOrder, fakeDice, board);

            Assert.AreEqual(turnOrder, turn.TurnOrder);
            Assert.AreEqual(player.Name, turn.Player);
            Assert.AreEqual(newLocation, turn.Location);
        }
    }
}
