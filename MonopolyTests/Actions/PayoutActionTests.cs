using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Actions;

namespace MonopolyTests.Actions
{
    [TestClass]
    public class PayoutActionTests
    {

        [TestMethod]
        public void ProcessActionAddsGivenAmountToPlayer()
        {
            var payoutAmount = 1000;
            var payoutAction = new PayoutAction(payoutAmount);
            var player = new Player("Name", 0, 0);
            var location = new FakeLocation();

            payoutAction.ProcessAction(player, location);

            Assert.AreEqual(payoutAmount, player.Balance);
        }
    }
}
