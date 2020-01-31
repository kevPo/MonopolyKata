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

            payoutAction.ProcessAction(player);

            Assert.AreEqual(payoutAmount, player.Balance);
        }
    }
}
