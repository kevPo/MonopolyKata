using System.Linq;
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
            var mortgageBroker = new MortgageBroker();
            var mortgageAdvisor = new MortgageAdvisor();
            var mortgageService = new MortgageService(board, mortgageAdvisor, mortgageBroker);
            turnService = new TurnService(mortgageService);
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

            Assert.AreEqual(6, result.Locations[0]);
            Assert.AreEqual(10, result.Locations[1]);
            Assert.AreEqual(2, result.Locations.Count);
            Assert.AreEqual(10, result.EndingLocation);
        }

        [TestMethod]
        public void PlayerOnlyMovesForOneRollWhenNotRollingDoubles()
        {
            fakeDice.LoadRoll(1, 3);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(4, result.Locations[0]);
            Assert.AreEqual(1, result.Locations.Count);
            Assert.AreEqual(4, result.EndingLocation);
        }

        [TestMethod]
        public void PlayerGetsTwoAdditionalTurnsWhenRollingDoublesTwice()
        {
            fakeDice.LoadRoll(3, 3);
            fakeDice.LoadRoll(3, 3);
            fakeDice.LoadRoll(1, 3);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(6, result.Locations[0]);
            Assert.AreEqual(12, result.Locations[1]);
            Assert.AreEqual(16, result.Locations[2]);
            Assert.AreEqual(3, result.Locations.Count);
            Assert.AreEqual(16, result.EndingLocation);
        }

        [TestMethod]
        public void PlayerEndsUpInJailWhenRollingDoublesThreeTimes()
        {
            fakeDice.LoadRoll(3, 3);
            fakeDice.LoadRoll(3, 3);
            fakeDice.LoadRoll(3, 3);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(6, result.Locations[0]);
            Assert.AreEqual(12, result.Locations[1]);
            Assert.AreEqual(LocationConstants.JailIndex, result.Locations[2]);
            Assert.AreEqual(3, result.Locations.Count);
            Assert.AreEqual(LocationConstants.JailIndex, result.EndingLocation);
        }

        [TestMethod]
        public void PlayerMortgagesPropertyAtTheBeginningOfTurn()
        {
            player.DepositMoney(new Money(500));
            var property = board.PropertyDictionary[LocationConstants.MediterraneanAveIndex];
            property.TransitionOwnership(player);
            fakeDice.LoadRoll(1, 2);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.IsTrue(property.IsMortgaged);
            Assert.AreEqual(1, result.PreTurnMortgageActivity[0].MortgagedProperties.Count(p => p.LocationIndex == LocationConstants.MediterraneanAveIndex));
        }

        [TestMethod]
        public void PlayerDoesNotMortgagePropertyAtTheBeginningOfTurn()
        {
            player.DepositMoney(new Money(1250));
            var property = board.PropertyDictionary[LocationConstants.MediterraneanAveIndex];
            property.TransitionOwnership(player);
            fakeDice.LoadRoll(1, 2);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.IsFalse(property.IsMortgaged);
            Assert.IsFalse(result.PreTurnMortgageActivity[0].MortgagedProperties.Any(p => p.LocationIndex == LocationConstants.MediterraneanAveIndex));
        }

        [TestMethod]
        public void PlayerMortgagesPropertyAtTheEndOfTurn()
        {
            player.DepositMoney(new Money(1001));
            var property = board.PropertyDictionary[LocationConstants.MediterraneanAveIndex];
            property.TransitionOwnership(player);
            fakeDice.LoadRoll(1, 2);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.IsTrue(property.IsMortgaged);
            Assert.AreEqual(1, result.PostTurnMortgageActivity[0].MortgagedProperties.Count(p => p.LocationIndex == LocationConstants.MediterraneanAveIndex));
        }

        [TestMethod]
        public void PlayerDoesNotMortgagePropertyAtTheEndOfTurn()
        {
            player.DepositMoney(new Money(1250));
            var property = board.PropertyDictionary[LocationConstants.MediterraneanAveIndex];
            property.TransitionOwnership(player);
            fakeDice.LoadRoll(1, 2);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.IsFalse(property.IsMortgaged);
            Assert.IsFalse(result.PostTurnMortgageActivity[0].MortgagedProperties.Any(p => p.LocationIndex == LocationConstants.MediterraneanAveIndex));
        }

        [TestMethod]
        public void PlayerPaysOffMortgageAtTheBeginningOfTurn()
        {
            player.DepositMoney(new Money(1001));
            player.Location = 38;
            var property = board.PropertyDictionary[LocationConstants.MediterraneanAveIndex];
            property.TransitionOwnership(player);
            property.MortgageProperty();
            fakeDice.LoadRoll(1, 2);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.IsFalse(property.IsMortgaged);
            Assert.AreEqual(1, result.PreTurnMortgageActivity[0].PaidOffProperties.Count(p => p.LocationIndex == LocationConstants.MediterraneanAveIndex));
        }

        [TestMethod]
        public void PlayerDoesNotPayOffMortgageAtTheBeginningOfTurn()
        {
            player.DepositMoney(new Money(600));
            player.Location = 38;
            var property = board.PropertyDictionary[LocationConstants.MediterraneanAveIndex];
            property.TransitionOwnership(player);
            property.MortgageProperty();
            fakeDice.LoadRoll(1, 2);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.IsTrue(property.IsMortgaged);
            Assert.IsFalse(result.PreTurnMortgageActivity[0].PaidOffProperties.Any(p => p.LocationIndex == LocationConstants.MediterraneanAveIndex));
        }

        [TestMethod]
        public void PlayerPaysOffMortgageAtTheEndOfTurn()
        {
            player.DepositMoney(new Money(999));
            player.Location = 38;
            var property = board.PropertyDictionary[LocationConstants.MediterraneanAveIndex];
            property.TransitionOwnership(player);
            property.MortgageProperty();
            fakeDice.LoadRoll(1, 2);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.IsFalse(property.IsMortgaged);
            Assert.AreEqual(1, result.PostTurnMortgageActivity[0].PaidOffProperties.Count(p => p.LocationIndex == LocationConstants.MediterraneanAveIndex));
        }

        [TestMethod]
        public void PlayerDoesNotPayOffMortgageAtTheEndOfTurn()
        {
            player.DepositMoney(new Money(600));
            player.Location = 38;
            var property = board.PropertyDictionary[LocationConstants.MediterraneanAveIndex];
            property.TransitionOwnership(player);
            property.MortgageProperty();
            fakeDice.LoadRoll(1, 2);

            var result = turnService.Take(0, player, board, fakeDice);

            Assert.IsTrue(property.IsMortgaged);
            Assert.IsFalse(result.PostTurnMortgageActivity[0].PaidOffProperties.Any(p => p.LocationIndex == LocationConstants.MediterraneanAveIndex));
        }

        [TestMethod]
        public void PlayerIsInJailAfterLandingOnGoToJail()
        {
            player.Location = 27;
            fakeDice.LoadRoll(1, 2);

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(LocationConstants.JailIndex, player.Location);
            Assert.IsTrue(player.IsInJail);
        }

        [TestMethod]
        public void PlayerIsInJailAfterLandingOnGoToJailWhenRollingDoubles()
        {
            player.Location = 26;
            fakeDice.LoadRoll(2, 2);

            turnService.Take(0, player, board, fakeDice);

            Assert.AreEqual(LocationConstants.JailIndex, player.Location);
            Assert.IsTrue(player.IsInJail);
        }
    }
}
