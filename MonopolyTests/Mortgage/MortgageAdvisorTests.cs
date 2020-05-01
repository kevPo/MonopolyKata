using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Mortgage;
using MonopolyTests.Fakes;

namespace MonopolyTests.Mortgage
{
    [TestClass]
    public class MortgageAdvisorTests
    {
        private readonly IMortgageAdvisor mortgageAdvisor;
        private readonly IPlayer horse;

        public MortgageAdvisorTests()
        {
            mortgageAdvisor = new MortgageAdvisor();
            horse = new Player("horse");
        }

        [TestMethod]
        public void PlayerShouldMortgagePropertyReturnsFalseWhenPlayerDoesNotOwn()
        {
            var car = new Player("car");
            var property = new FakeProperty(owner: car);

            Assert.IsFalse(mortgageAdvisor.PlayerShouldMortgageProperty(horse, property));
        }

        [TestMethod]
        public void PlayerShouldMortgagePropertyReturnsFalseWhenPropertyIsNotOwned()
        {
            var property = new FakeProperty();

            Assert.IsFalse(mortgageAdvisor.PlayerShouldMortgageProperty(horse, property));
        }

        [TestMethod]
        public void PlayerShouldMortgagePropertyReturnsFalseWhenPropertyIsAlreadyMortgaged()
        {
            var property = new FakeProperty(owner: horse, isMortgaged: true);

            Assert.IsFalse(mortgageAdvisor.PlayerShouldMortgageProperty(horse, property));
        }

        [TestMethod]
        public void PlayerShouldMortgagePropertyReturnsTrueWhenBalanceIsLessThanOneThousand()
        {
            horse.DepositMoney(new Money(200));
            var property = new FakeProperty(owner: horse);

            Assert.IsTrue(mortgageAdvisor.PlayerShouldMortgageProperty(horse, property));
        }

        [TestMethod]
        public void PlayerShouldMortgagePropertyReturnsTrueWhenBalanceIsEqualToOneThousand()
        {
            horse.DepositMoney(new Money(1000));
            var property = new FakeProperty(owner: horse);

            Assert.IsTrue(mortgageAdvisor.PlayerShouldMortgageProperty(horse, property));
        }

        [TestMethod]
        public void PlayerShouldMortgagePropertyReturnsFalseWhenBalanceIsGreaterThanOneThousand()
        {
            horse.DepositMoney(new Money(1001));
            var property = new FakeProperty(owner: horse);

            Assert.IsFalse(mortgageAdvisor.PlayerShouldMortgageProperty(horse, property));
        }

        [TestMethod]
        public void PlayerShouldPayOffMortgageReturnsFalseWhenPlayerDoesNotOwn()
        {
            var car = new Player("car");
            var property = new FakeProperty(owner: car);

            Assert.IsFalse(mortgageAdvisor.PlayerShouldPayOffMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerShouldPayOffMortgageReturnsFalseWhenPropertyIsNotOwned()
        {
            var property = new FakeProperty();

            Assert.IsFalse(mortgageAdvisor.PlayerShouldPayOffMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerShouldPayOffMortgageReturnsTrueWhenBalanceIsGreaterThanOneThousand()
        {
            horse.DepositMoney(new Money(1200));
            var property = new FakeProperty(owner: horse, isMortgaged: true);

            Assert.IsTrue(mortgageAdvisor.PlayerShouldPayOffMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerShouldPayOffMortgageReturnsFalseWhenBalanceIsLessThanOneThousand()
        {
            horse.DepositMoney(new Money(200));
            var property = new FakeProperty(owner: horse, isMortgaged: true);

            Assert.IsFalse(mortgageAdvisor.PlayerShouldPayOffMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerShouldPayOffMortgageReturnsFalseWhenBalanceIsEqualToOneThousand()
        {
            horse.DepositMoney(new Money(1000));
            var property = new FakeProperty(owner: horse, isMortgaged: true);

            Assert.IsFalse(mortgageAdvisor.PlayerShouldPayOffMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerShouldPayOffMortgageReturnsFalseWhenPropertyIsNotMortgaged()
        {
            horse.DepositMoney(new Money(1001));
            var property = new FakeProperty(owner: horse);

            Assert.IsFalse(mortgageAdvisor.PlayerShouldPayOffMortgage(horse, property));
        }
    }
}
