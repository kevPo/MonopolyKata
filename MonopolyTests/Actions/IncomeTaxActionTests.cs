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
            var player = new Player("Name", balance:1800);
            var taxAction = new IncomeTaxAction(10, 200);
            var expectedBalance = 1800 - 180;
            var location = new FakeLocation();

            taxAction.ProcessAction(player, location);

            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void ProcessActionAddsCharges200WhenPlayerBalanceIs2200()
        {
            var player = new Player("Name", balance:2200);
            var taxAction = new IncomeTaxAction(10, 200);
            var expectedBalance = 2200 - 200;
            var location = new FakeLocation();

            taxAction.ProcessAction(player, location);

            Assert.AreEqual(expectedBalance, player.Balance);
        }
    }
}
