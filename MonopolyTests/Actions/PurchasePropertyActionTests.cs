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
            var action = new PurchasePropertyAction(0);
            var location = new FakeLocation();

            action.ProcessAction(player, location);

            Assert.AreEqual(player.Name, location.Owner.Name);
        }

        [TestMethod]
        public void PlayerBalanceIsDecreasedByCostOfProperty()
        {
            var player = new Player("owner", 500);
            var action = new PurchasePropertyAction(100);
            var location = new FakeLocation();
            var expectedBalance = 500 - 100;

            action.ProcessAction(player, location);

            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerDoesNotPurchasePropertyIfBalanceWouldDropBelow0()
        {
            var player = new Player("owner", 50);
            var action = new PurchasePropertyAction(100);
            var location = new FakeLocation();

            action.ProcessAction(player, location);

            Assert.AreEqual(null, location.Owner);
        }

        [TestMethod]
        public void PlayerStillPurchasesPropertyIfBalanceWouldDropTo0()
        {
            var player = new Player("owner", 50);
            var action = new PurchasePropertyAction(50);
            var location = new FakeLocation();

            action.ProcessAction(player, location);

            Assert.AreEqual(player.Name, location.Owner.Name);
        }
    }
}
