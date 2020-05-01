using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Actions;
using MonopolyTests.Fakes;

namespace MonopolyTests.Actions
{
    [TestClass]
    public class RealEstateRentActionTests
    {
        [TestMethod]
        public void PlayerPaysRentToOwnerOfSingleProperty()
        {
            var startingMoney = new Money(100);
            var rent = new Money(5);
            var owner = new Player("car", startingMoney);
            var player = new Player("horse", startingMoney);
            var fakeProperty = new FakeProperty(owner: owner, rent: rent);
            var expectedOwnerMoney = startingMoney.Add(rent);
            var expectedPlayerMoney = startingMoney.Remove(rent);
            var rentAction = new RealEstateRentAction(new FakeBoard());

            rentAction.ProcessAction(player, fakeProperty);

            Assert.AreEqual(expectedOwnerMoney, owner.Balance);
            Assert.AreEqual(expectedPlayerMoney, player.Balance);
        }

        [TestMethod]
        public void PlayerPaysDoubleRentToOwnerOfPropertyGroup()
        {
            var startingMoney = new Money(100);
            var rent = new Money(5);
            var owner = new Player("car", startingMoney);
            var player = new Player("horse", startingMoney);
            var fakeProperty = new FakeProperty(owner: owner, rent: rent);
            var doubleRent = new Money(rent.Amount * 2);
            var expectedOwnerMoney = startingMoney.Add(doubleRent);
            var expectedPlayerMoney = startingMoney.Remove(doubleRent);
            var rentAction = new RealEstateRentAction(new FakeBoard(playerOwnsPropertyGroup: true));

            rentAction.ProcessAction(player, fakeProperty);

            Assert.AreEqual(expectedOwnerMoney, owner.Balance);
            Assert.AreEqual(expectedPlayerMoney, player.Balance);
        }
    }
}
