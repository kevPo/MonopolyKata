using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Actions;
using MonopolyTests.Fakes;

namespace MonopolyTests.Actions
{
    [TestClass]
    public class UtilityRentActionTests
    {
        [TestMethod]
        public void PlayerPaysRentToOwnerWhenOneUtilityIsOwned()
        {
            var startingMoney = new Money(100);
            var owner = new Player("car", startingMoney);
            var player = new Player("horse", startingMoney);
            var fakeProperty = new FakeProperty(owner: owner);
            var fakeDice = new FakeDice();
            fakeDice.LoadRoll(3, 7);
            fakeDice.Roll();
            var expectedRent = new Money(4 * fakeDice.LastRoll.Total);
            var expectedOwnerMoney = startingMoney.Add(expectedRent);
            var expectedPlayerMoney = startingMoney.Remove(expectedRent);
            var rentAction = new UtilityRentAction(new FakeBoard(numberOfUtilitiesOwned: 1), fakeDice);

            rentAction.ProcessAction(player, fakeProperty);

            Assert.AreEqual(expectedOwnerMoney, owner.Balance);
            Assert.AreEqual(expectedPlayerMoney, player.Balance);
        }

        [TestMethod]
        public void PlayerPaysRentToOwnerWhenBothUtilitiesAreOwned()
        {
            var startingMoney = new Money(100);
            var owner = new Player("car", startingMoney);
            var player = new Player("horse", startingMoney);
            var fakeProperty = new FakeProperty(owner: owner);
            var fakeDice = new FakeDice();
            fakeDice.LoadRoll(3, 7);
            fakeDice.Roll();
            var expectedRent = new Money(10 * fakeDice.LastRoll.Total);
            var expectedOwnerMoney = startingMoney.Add(expectedRent);
            var expectedPlayerMoney = startingMoney.Remove(expectedRent);
            var rentAction = new UtilityRentAction(new FakeBoard(numberOfUtilitiesOwned: 2), fakeDice);

            rentAction.ProcessAction(player, fakeProperty);

            Assert.AreEqual(expectedOwnerMoney, owner.Balance);
            Assert.AreEqual(expectedPlayerMoney, player.Balance);
        }
    }
}
