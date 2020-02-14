using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Actions;

namespace MonopolyTests.Actions
{
    [TestClass]
    public class IncomeTaxActionTests
    {

        [TestMethod]
        public void ProcessActionAddsCharges180WhenPlayerBalanceIs1800()
        {
            var playerMoney = new Money(1800);
            var expectedTaxAmount = new Money(180);
            var player = new Player("Name", balance: playerMoney);
            var taxAction = new IncomeTaxAction(MonopolyConstants.IncomeTaxRate, MonopolyConstants.IncomeTaxMaximumAmount);
            var expectedBalance = playerMoney.Remove(expectedTaxAmount);

            taxAction.ProcessAction(player);

            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void ProcessActionAddsCharges200WhenPlayerBalanceIs2200()
        {
            var playerMoney = new Money(2200);
            var expectedTaxAmount = new Money(200);
            var player = new Player("Name", balance: playerMoney);
            var taxAction = new IncomeTaxAction(MonopolyConstants.IncomeTaxRate, MonopolyConstants.IncomeTaxMaximumAmount);
            var expectedBalance = playerMoney.Remove(expectedTaxAmount);

            taxAction.ProcessAction(player);

            Assert.AreEqual(expectedBalance, player.Balance);
        }
    }
}
