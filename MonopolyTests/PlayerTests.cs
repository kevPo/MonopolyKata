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

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(0, player.Location);
            Assert.AreEqual(200, player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnNormalLocationAndBalanceDoesNotChange()
        {
            dice.LoadRoll(11);

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(11, player.Location);
            Assert.AreEqual(0, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesGoAndGets200DollarsAddedToBalance()
        {
            dice.LoadRolls(new[] { 39, 2 });
            player.TakeTurn(0, dice, board);

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(1, player.Location);
            Assert.AreEqual(200, player.Balance);
        }

        [TestMethod]
        public void StartsOnGoDoesNotLandOrPassOnGoAndBalanceRemainsUnchanged()
        {
            dice.LoadRoll(4);

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(0, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesGoTwiceInOneTurnAndGains400ToBalance()
        {
            dice.LoadRoll(81);

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(400, player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnGoToJailAndMovesDirectlyToJustVisiting()
        {
            dice.LoadRolls(new[] { 29, 1 });
            player.TakeTurn(0, dice, board);
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(10, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverGoToJailWithLocationAndBalanceUnchanged()
        {
            dice.LoadRolls(new[] { 29, 2 });
            player.TakeTurn(0, dice, board);
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(31, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }
    }
}
