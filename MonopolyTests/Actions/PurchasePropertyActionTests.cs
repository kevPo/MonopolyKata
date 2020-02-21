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
            var property = new FakeProperty();
            var action = new PurchasePropertyAction();

            action.ProcessAction(player, property);

            Assert.AreEqual(player.Name, property.Owner.Name);
        }

        [TestMethod]
        public void PlayerBalanceIsDecreasedByCostOfProperty()
        {
            var playerMoney = new Money(500);
            var propertyCost = new Money(100);
            var player = new Player("owner", playerMoney);
            var property = new FakeProperty(cost: propertyCost);
            var action = new PurchasePropertyAction();
            var expectedBalance = playerMoney.Remove(propertyCost);

            action.ProcessAction(player, property);

            Assert.AreEqual(expectedBalance, player.Balance);
        }

        [TestMethod]
        public void PlayerDoesNotPurchasePropertyIfBalanceWouldDropBelow0()
        {
            var player = new Player("owner", new Money(50));
            var property = new FakeProperty(cost: new Money(100));
            var action = new PurchasePropertyAction();

            action.ProcessAction(player, property);

            Assert.AreEqual(null, property.Owner);
        }

        [TestMethod]
        public void PlayerStillPurchasesPropertyIfBalanceWouldDropTo0()
        {
            var player = new Player("owner", new Money(50));
            var property = new FakeProperty(cost: new Money(50));
            var action = new PurchasePropertyAction();

            action.ProcessAction(player, property);

            Assert.AreEqual(player.Name, property.Owner.Name);
        }
    }
}
