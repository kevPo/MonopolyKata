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
            var payoutAmount = new Money(1000);
            var payoutAction = new PayoutAction(payoutAmount);
            var player = new Player("Name");

            payoutAction.ProcessAction(player);

            Assert.AreEqual(payoutAmount, player.Balance);
        }
    }
}
