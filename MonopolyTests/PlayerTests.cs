using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class PlayerTests
    {
        private Player player;
        private Board board;
        private FakeDice dice;

        public PlayerTests()
        {
            player = new Player("Horse");
            dice = new FakeDice();
            board = new Board();
        }

        [TestMethod]
        public void TakeTurnReturnsNewTurnWithNewLocationFromBoard()
        {
            var turnOrder = 0;
            var newLocation = 10;
            dice.LoadRoll(10);

            var turn = player.TakeTurn(turnOrder, dice, board);

            Assert.AreEqual(turnOrder, turn.TurnOrder);
            Assert.AreEqual(player.Name, turn.Player);
            Assert.AreEqual(newLocation, turn.Location);
        }

        [TestMethod]
        public void PlayerLandsOnGoAndGets200DollarsAddedToBalance()
        {
            dice.LoadRolls(new[] { 39, 1 });
            player.TakeTurn(0, dice, board);

            var turn = player.TakeTurn(0, dice, board);

            Assert.AreEqual(0, turn.Location);
            Assert.AreEqual(200, player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnNormalLocationAndBalanceDoesNotChange()
        {
            dice.LoadRoll(11);

            var turn = player.TakeTurn(0, dice, board);

            Assert.AreEqual(11, turn.Location);
            Assert.AreEqual(0, player.Balance);
        }
    }
}
