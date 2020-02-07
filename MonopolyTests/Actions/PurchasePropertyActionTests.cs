using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Actions;

namespace MonopolyTests.Actions
{
    [TestClass]
    public class PurchasePropertyActionTests
    {
        [TestMethod]
        public void LocationIsOwnedByPlayerAfterPurchase()
        {
            var player = new Player("owner");
            var property = new FakeProperty(cost: 0);
            var action = new PurchasePropertyAction(property);

            action.ProcessAction(player);

            Assert.AreEqual(player.Name, property.Owner.Name);
        }

        [TestMethod]
        public void PlayerBalanceIsDecreasedByCostOfProperty()
        {
            var player = new Player("owner", 500);
            var property = new FakeProperty(cost: 100);
            var action = new PurchasePropertyAction(property);
            var expectedBalance = 500 - 100;

            action.ProcessAction(player);

            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerDoesNotPurchasePropertyIfBalanceWouldDropBelow0()
        {
            var player = new Player("owner", 50);
            var property = new FakeProperty(cost: 100);
            var action = new PurchasePropertyAction(property);

            action.ProcessAction(player);

            Assert.AreEqual(null, property.Owner);
        }

        [TestMethod]
        public void PlayerStillPurchasesPropertyIfBalanceWouldDropTo0()
        {
            var player = new Player("owner", 50);
            var property = new FakeProperty(cost: 50);
            var action = new PurchasePropertyAction(property);

            action.ProcessAction(player);

            Assert.AreEqual(player.Name, property.Owner.Name);
        }
    }
}
