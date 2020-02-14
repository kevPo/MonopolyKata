using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Locations;

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
            Assert.AreEqual(MonopolyConstants.GoPayoutAmount, player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnNormalLocationAndBalanceDoesNotChange()
        {
            dice.LoadRoll(11);

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(11, player.Location);
            Assert.AreEqual(MonopolyConstants.NoMoney, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesGoAndGets200DollarsAddedToBalance()
        {
            dice.LoadRolls(new[] { 39, 3 });
            player.TakeTurn(0, dice, board);

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(2, player.Location);
            Assert.AreEqual(MonopolyConstants.GoPayoutAmount, player.Balance);
        }

        [TestMethod]
        public void StartsOnGoDoesNotLandOrPassOnGoAndBalanceRemainsUnchanged()
        {
            dice.LoadRoll(4);

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(MonopolyConstants.NoMoney, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesGoTwiceInOneTurnAndGains400ToBalance()
        {
            var expectedBalance = MonopolyConstants.GoPayoutAmount.Add(MonopolyConstants.GoPayoutAmount);
            dice.LoadRoll(82);

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(expectedBalance, player.Balance);
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

        [TestMethod]
        public void PlayerPays180WhenPlayerLandsOnIncomeTaxAndBalanceIs1800()
        {
            dice.LoadRolls(new[] { 3, 1 });
            player.Balance = new Money(1800);
            player.TakeTurn(0, dice, board);
            var expectedBalance = player.Balance.Remove(new Money(180));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays200WhenPlayerLandsOnIncomeTaxAndBalanceIs2200()
        {
            dice.LoadRolls(new[] { 3, 1 });
            player.Balance = new Money(2200);
            player.TakeTurn(0, dice, board);
            var expectedBalance = player.Balance.Remove(new Money(200));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays0WhenPlayerLandsOnIncomeTaxAndBalanceIs0()
        {
            dice.LoadRolls(new[] { 3, 1 });
            player.TakeTurn(0, dice, board);
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays200WhenPlayerLandsOnIncomeTaxAndBalanceIs2000()
        {
            dice.LoadRolls(new[] { 3, 1 });
            player.Balance = new Money(2000);
            player.TakeTurn(0, dice, board);
            var expectedBalance = player.Balance.Remove(new Money(200));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverIncomeTaxAndNothingHappens()
        {
            dice.LoadRolls(new[] { 3, 2 });
            player.Balance = new Money(2000);
            player.TakeTurn(0, dice, board);
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(5, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays75WhenPlayerLandsOnLuxuryTax()
        {
            dice.LoadRolls(new[] { 37, 1 });
            player.Balance = new Money(100);
            player.TakeTurn(0, dice, board);
            var expectedBalance = player.Balance.Remove(new Money(75));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(38, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverLuxuryTaxAndNothingHappens()
        {
            dice.LoadRolls(new[] { 37, 2 });
            player.Balance = new Money(100);
            player.TakeTurn(0, dice, board);
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(39, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnUnownedPropertyAndBuysIt()
        {
            dice.LoadRolls(new[] { 1 });
            player.Balance = new Money(100);

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(player.Name, (board.Locations.ElementAt(1) as IProperty).Owner.Name);
        }
       
        [TestMethod]
        public void PlayerLandsOnOwnedPropertyAndNothingHappens()
        {
            dice.LoadRolls(new[] { 1 });
            (board.Locations.ElementAt(1) as IProperty).PurchaseProperty(player);
            player.Balance = new Money(100);
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(expectedBalance, player.Balance);
        }
       
        [TestMethod]
        public void PlayerPassesOverUnownedPropertyAndNothingHappens()
        {
            dice.LoadRolls(new[] { 2 });
            player.Balance = new Money(100);
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.IsNull((board.Locations.ElementAt(1) as IProperty).Owner);
            Assert.AreEqual(expectedBalance, player.Balance);
        }
    }
}
