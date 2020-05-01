using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Actions;
using Monopoly.Locations;
using MonopolyTests.Fakes;

namespace MonopolyTests.Actions
{
    [TestClass]
    public class RailroadRentActionTests
    {
        private readonly Money startingMoney;
        private readonly IPlayer owner;
        private readonly IPlayer player;
        private readonly IProperty fakeProperty;

        public RailroadRentActionTests()
        {
            startingMoney = new Money(100);
            owner = new Player("car", startingMoney);
            player = new Player("horse", startingMoney);
            fakeProperty = new FakeProperty(owner: owner);
        }

        [TestMethod]
        public void PlayerPaysRentToOwnerOfSingleRailroad()
        {
            var expectedRent = new Money(25);
            var expectedOwnerMoney = startingMoney.Add(expectedRent);
            var expectedPlayerMoney = startingMoney.Remove(expectedRent);
            var rentAction = new RailroadRentAction(new FakeBoard(numberOfRailroadsOwnedByPlayer: 1));

            rentAction.ProcessAction(player, fakeProperty);

            Assert.AreEqual(expectedOwnerMoney, owner.Balance);
            Assert.AreEqual(expectedPlayerMoney, player.Balance);
        }

        [TestMethod]
        public void PlayerPaysRentToOwnerOfTwoRailroads()
        {
            var expectedRent = new Money(50);
            var expectedOwnerMoney = startingMoney.Add(expectedRent);
            var expectedPlayerMoney = startingMoney.Remove(expectedRent);
            var rentAction = new RailroadRentAction(new FakeBoard(numberOfRailroadsOwnedByPlayer: 2));

            rentAction.ProcessAction(player, fakeProperty);

            Assert.AreEqual(expectedOwnerMoney, owner.Balance);
            Assert.AreEqual(expectedPlayerMoney, player.Balance);
        }

        [TestMethod]
        public void PlayerPaysRentToOwnerOfThreeRailroads()
        {
            var expectedRent = new Money(75);
            var expectedOwnerMoney = startingMoney.Add(expectedRent);
            var expectedPlayerMoney = startingMoney.Remove(expectedRent);
            var rentAction = new RailroadRentAction(new FakeBoard(numberOfRailroadsOwnedByPlayer: 3));

            rentAction.ProcessAction(player, fakeProperty);

            Assert.AreEqual(expectedOwnerMoney, owner.Balance);
            Assert.AreEqual(expectedPlayerMoney, player.Balance);
        }

        [TestMethod]
        public void PlayerPaysRentToOwnerOfFourRailroads()
        {
            var expectedRent = new Money(100);
            var expectedOwnerMoney = startingMoney.Add(expectedRent);
            var expectedPlayerMoney = startingMoney.Remove(expectedRent);
            var rentAction = new RailroadRentAction(new FakeBoard(numberOfRailroadsOwnedByPlayer: 4));

            rentAction.ProcessAction(player, fakeProperty);

            Assert.AreEqual(expectedOwnerMoney, owner.Balance);
            Assert.AreEqual(expectedPlayerMoney, player.Balance);
        }
    }
}
