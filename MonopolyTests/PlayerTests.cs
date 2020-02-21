using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Locations;

namespace MonopolyTests
{
    [TestClass]
    public class PlayerTests
    {
        private FakeDice dice;
        private Board board;

        public PlayerTests()
        {
            dice = new FakeDice();
            board = new Board(dice);
        }

        [TestMethod]
        public void TakeTurnReturnsNewTurnWithNewLocationFromBoard()
        {
            var player = new Player("horse");
            var turnOrder = 0;
            var newLocation = 10;
            dice.LoadRoll((4, 6));

            var turn = player.TakeTurn(turnOrder, dice, board);

            Assert.AreEqual(turnOrder, turn.TurnOrder);
            Assert.AreEqual(player.Name, turn.Player);
            Assert.AreEqual(newLocation, turn.Location);
        }

        [TestMethod]
        public void PlayerLandsOnGoAndGets200DollarsAddedToBalance()
        {
            var player = new Player("horse", location: 39);
            dice.LoadRoll((1, 0));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(0, player.Location);
            Assert.AreEqual(MonopolyConstants.GoPayoutAmount, player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnNormalLocationAndBalanceDoesNotChange()
        {
            var player = new Player("horse");
            dice.LoadRoll((5, 6));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(11, player.Location);
            Assert.AreEqual(MonopolyConstants.NoMoney, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesGoAndGets200DollarsAddedToBalance()
        {
            var player = new Player("horse", location: 39);
            dice.LoadRoll((1, 2));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(2, player.Location);
            Assert.AreEqual(MonopolyConstants.GoPayoutAmount, player.Balance);
        }

        [TestMethod]
        public void StartsOnGoDoesNotLandOrPassOnGoAndBalanceRemainsUnchanged()
        {
            var player = new Player("horse");
            dice.LoadRoll((1, 3));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(MonopolyConstants.NoMoney, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesGoTwiceInOneTurnAndGains400ToBalance()
        {
            var player = new Player("horse");
            dice.LoadRoll((1, 81));
            var expectedBalance = MonopolyConstants.GoPayoutAmount.Add(MonopolyConstants.GoPayoutAmount);

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnGoToJailAndMovesDirectlyToJustVisiting()
        {
            var player = new Player("horse", location: 29);
            dice.LoadRoll((1, 0));
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(10, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverGoToJailWithLocationAndBalanceUnchanged()
        {
            var player = new Player("horse", location: 29);
            dice.LoadRoll((1, 1));
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(31, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays180WhenPlayerLandsOnIncomeTaxAndBalanceIs1800()
        {
            var player = new Player("horse", new Money(1800));
            dice.LoadRoll((1, 3));
            var expectedBalance = player.Balance.Remove(new Money(180));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays200WhenPlayerLandsOnIncomeTaxAndBalanceIs2200()
        {
            var player = new Player("horse", new Money(2200));
            dice.LoadRoll((1, 3));
            var expectedBalance = player.Balance.Remove(new Money(200));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays0WhenPlayerLandsOnIncomeTaxAndBalanceIs0()
        {
            var player = new Player("horse", location: 3);
            dice.LoadRoll((1, 0));
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays200WhenPlayerLandsOnIncomeTaxAndBalanceIs2000()
        {
            var player = new Player("horse", new Money(2000));
            dice.LoadRoll((1, 3));
            var expectedBalance = player.Balance.Remove(new Money(200));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverIncomeTaxAndBalanceIsUnchanged()
        {
            var player = new Player("horse", new Money(2000));
            dice.LoadRoll((4, 6));
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays75WhenPlayerLandsOnLuxuryTax()
        {
            var player = new Player("horse", new Money(100), 37);
            dice.LoadRoll((1, 0));
            var expectedBalance = player.Balance.Remove(new Money(75));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(38, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverLuxuryTaxAndNothingHappens()
        {
            var player = new Player("horse", new Money(100), 37);
            dice.LoadRoll((1, 1));
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(39, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnUnownedPropertyAndBuysIt()
        {
            var player = new Player("horse", new Money(100));
            dice.LoadRoll((1, 0));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(player.Name, (board.Locations.ElementAt(1) as IProperty).Owner.Name);
        }
       
        [TestMethod]
        public void PlayerLandsOnOwnedPropertyAndDoesNotBuyIt()
        {
            var owner = new Player("owner", balance: new Money(100));
            var property = (board.Locations.ElementAt(1) as IProperty);
            property.TransitionOwnership(owner);
            var player = new Player("horse", new Money(100));
            dice.LoadRoll((1, 0));

            player.TakeTurn(0, dice, board);

            Assert.AreEqual(owner, property.Owner);
        }
       
        [TestMethod]
        public void PlayerPassesOverUnownedPropertyAndNothingHappens()
        {
            var player = new Player("horse", new Money(100));
            dice.LoadRoll((1, 1));
            var expectedBalance = player.Balance;

            player.TakeTurn(0, dice, board);

            Assert.IsNull((board.Locations.ElementAt(1) as IProperty).Owner);
            Assert.AreEqual(expectedBalance, player.Balance);
        }
    }
}
