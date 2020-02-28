using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class PlayerTests
    {
        private readonly IPlayer player;

        public PlayerTests()
        {
            player = new Player("horse");
        }

        [TestMethod]
        public void DepositMoneyAddsMoneyToPlayerBalanceAndReturnsTrue()
        {
            var expectedBalance = new Money(100);

            var result = player.DepositMoney(expectedBalance);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void WithdrawMoneySubtractsMoneyFromPlayerBalanceAndReturnsTrueWhenPlayerHasAvailableFunds()
        {
            var expectedBalance = new Money(100);
            player.DepositMoney(new Money(200));

            var result = player.WithdrawMoney(expectedBalance);

            Assert.IsTrue(result);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void WithdrawMoneyDoesNotSubtractMoneyFromPlayerBalanceAndReturnsFalseWhenPlayerDoesNotHaveAvailableFunds()
        {
            var expectedBalance = new Money(50);
            player.DepositMoney(expectedBalance);

            var result = player.WithdrawMoney(new Money(51));

            Assert.IsFalse(result);
            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void HasAvailableFundsReturnsTrueWhenPlayerBalanceIsGreaterThanAmount()
        {
            player.DepositMoney(new Money(1000));
            Assert.IsTrue(player.HasAvailableFunds(new Money(500)));
        }

        [TestMethod]
        public void HasAvailableFundsReturnsFalseWhenPlayerBalanceIsLessThanAmount()
        {
            player.DepositMoney(new Money(500));
            Assert.IsFalse(player.HasAvailableFunds(new Money(600)));
        }

        [TestMethod]
        public void HasAvailableFundsReturnsFalseWhenPlayerBalanceIsEqualToAmount()
        {
            player.DepositMoney(new Money(500));
            Assert.IsTrue(player.HasAvailableFunds(new Money(500)));
        }
    }
}
