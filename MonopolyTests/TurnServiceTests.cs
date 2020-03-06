using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Locations;

namespace MonopolyTests
{
    [TestClass]
    public class TurnServiceTests
    {
        private const int TurnOrder = 0;

        private readonly FakeDice fakeDice;
        private readonly IPlayer player;
        private readonly ITurnService turnService;
        private readonly IBoard board;

        public TurnServiceTests()
        {
            fakeDice = new FakeDice();
            board = new Board(fakeDice);
            player = new Player("horse");
            turnService = new TurnService();
        }

        [TestMethod]
        public void TakeTurnReturnsNewTurnWithNewLocationFromBoard()
        {
            var turnOrder = 0;
            var newLocation = 10;
            fakeDice.LoadRoll(4, 6);

            var turn = turnService.Take(TurnOrder, player, board, fakeDice);

            Assert.AreEqual(turnOrder, turn.TurnOrder);
            Assert.AreEqual(player.Name, turn.PlayerName);
            Assert.AreEqual(newLocation, turn.EndingLocation);
        }

        [TestMethod]
        public void PlayerLandsOnGoAndGets200DollarsAddedToBalance()
        {
            player.Location = 39;
            fakeDice.LoadRoll(1, 0);

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(0, player.Location);
            Assert.AreEqual(MonopolyConstants.GoPayoutAmount, player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnNormalLocationAndBalanceDoesNotChange()
        {
            fakeDice.LoadRoll(5, 6);

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(11, player.Location);
            Assert.AreEqual(MonopolyConstants.NoMoney, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesGoAndGets200DollarsAddedToBalance()
        {
            player.Location = 39;
            fakeDice.LoadRoll(1, 2);

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(2, player.Location);
            Assert.AreEqual(MonopolyConstants.GoPayoutAmount, player.Balance);
        }

        [TestMethod]
        public void StartsOnGoDoesNotLandOrPassOnGoAndBalanceRemainsUnchanged()
        {
            fakeDice.LoadRoll(1, 3);

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(MonopolyConstants.NoMoney, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesGoTwiceInOneTurnAndGains400ToBalance()
        {
            fakeDice.LoadRoll(1, 81);
            var expectedBalance = MonopolyConstants.GoPayoutAmount.Add(MonopolyConstants.GoPayoutAmount);

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnGoToJailAndMovesDirectlyToJustVisiting()
        {
            player.Location = 27;
            fakeDice.LoadRoll(1, 2);
            var expectedBalance = player.Balance;

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(10, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverGoToJailWithLocationAndBalanceUnchanged()
        {
            player.Location = 28;
            fakeDice.LoadRoll(2, 1);
            var expectedBalance = player.Balance;

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(31, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays180WhenPlayerLandsOnIncomeTaxAndBalanceIs1800()
        {
            player.DepositMoney(new Money(1800));
            fakeDice.LoadRoll(1, 3);
            var expectedBalance = player.Balance.Remove(new Money(180));

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays200WhenPlayerLandsOnIncomeTaxAndBalanceIs2200()
        {
            player.DepositMoney(new Money(2200));
            fakeDice.LoadRoll(1, 3);
            var expectedBalance = player.Balance.Remove(new Money(200));

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays0WhenPlayerLandsOnIncomeTaxAndBalanceIs0()
        {
            player.Location = 3;
            fakeDice.LoadRoll(1, 0);
            var expectedBalance = player.Balance;

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays200WhenPlayerLandsOnIncomeTaxAndBalanceIs2000()
        {
            player.DepositMoney(new Money(2000));
            fakeDice.LoadRoll(1, 3);
            var expectedBalance = player.Balance.Remove(new Money(200));

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(4, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverIncomeTaxAndBalanceIsUnchanged()
        {
            player.DepositMoney(new Money(2000));
            fakeDice.LoadRoll(4, 6);
            var expectedBalance = player.Balance;

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPays75WhenPlayerLandsOnLuxuryTax()
        {
            player.Location = 37;
            player.DepositMoney(new Money(100));
            fakeDice.LoadRoll(1, 0);
            var expectedBalance = player.Balance.Remove(new Money(75));

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(38, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverLuxuryTaxAndNothingHappens()
        {
            player.Location = 36;
            player.DepositMoney(new Money(100));
            fakeDice.LoadRoll(2, 1);
            var expectedBalance = player.Balance;

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(39, player.Location);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnUnownedPropertyAndBuysIt()
        {
            player.DepositMoney(new Money(100));
            fakeDice.LoadRoll(1, 0);

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(player.Name, (board.Locations[1] as IProperty).Owner.Name);
        }

        [TestMethod]
        public void PlayerLandsOnOwnedPropertyAndDoesNotBuyIt()
        {
            player.DepositMoney(new Money(100));
            var owner = new Player("owner", balance: new Money(100));
            var property = (board.Locations[1] as IProperty);
            property.TransitionOwnership(owner);
            fakeDice.LoadRoll(1, 0);

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(owner, property.Owner);
        }

        [TestMethod]
        public void PlayerPassesOverUnownedPropertyAndNothingHappens()
        {
            player.DepositMoney(new Money(100));
            fakeDice.LoadRoll(4, 6);
            var expectedBalance = player.Balance;

            turnService.Take(0, player, board, fakeDice);

            Assert.IsNull((board.Locations[1] as IProperty).Owner);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerGetAdditionalTurnWhenRollingDoubles()
        {
            fakeDice.LoadRoll(3, 3);
            fakeDice.LoadRoll(1, 3);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.IsTrue(result.Locations.Contains(6));
            Assert.IsTrue(result.Locations.Contains(10));
        }
    }
}
