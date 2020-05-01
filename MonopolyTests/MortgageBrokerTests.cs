using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Mortgage;

namespace MonopolyTests
{
    [TestClass]
    public class MortgageBrokerTests
    {
        private readonly IMortgageBroker mortgageBroker;
        private readonly IPlayer horse;

        public MortgageBrokerTests()
        {
            mortgageBroker = new MortgageBroker();
            horse = new Player("horse");
        }

        [TestMethod]
        public void PlayerCannotMortgagePropertyThatTheyDoNotOwn()
        {
            var car = new Player("car");
            var property = new FakeProperty(owner: car);

            Assert.IsFalse(mortgageBroker.TakeOutMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerCannotMortgagePropertyThatIsNotOwned()
        {
            var property = new FakeProperty();

            Assert.IsFalse(mortgageBroker.TakeOutMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerCannotMortgagePropertyThatIsAlreadyMortgaged()
        {
            var property = new FakeProperty(owner: horse, isMortgaged: true);

            Assert.IsFalse(mortgageBroker.TakeOutMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerSuccessfullyTakesOutAMortgageAndBalanceIncreases90PercentOfOrignalPropertyCost()
        {
            horse.DepositMoney(new Money(200));
            var propertyCost = new Money(100);
            var property = new FakeProperty(owner: horse, cost: propertyCost);
            var expectedPlayerBalance = new Money(290);

            Assert.IsTrue(mortgageBroker.TakeOutMortgage(horse, property));
            Assert.AreEqual(expectedPlayerBalance, horse.Balance);
        }

        [TestMethod]
        public void PlayerCannotPayOffMortgageForPropertyTheyDoNotOwn()
        {
            var car = new Player("car");
            var property = new FakeProperty(owner: car);

            Assert.IsFalse(mortgageBroker.PayOffMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerCannotPayOffMortgageForPropertyThatIsNotOwned()
        {
            var property = new FakeProperty();

            Assert.IsFalse(mortgageBroker.PayOffMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerCannotPayOffMortgageForPropertyThatIsNotMortgaged()
        {
            var property = new FakeProperty(owner: horse);

            Assert.IsFalse(mortgageBroker.PayOffMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerPaysOffMortgageAndBalanceDecreasesByPropertyCost()
        {
            horse.DepositMoney(new Money(200));
            var propertyCost = new Money(100);
            var property = new FakeProperty(owner: horse, isMortgaged: true, cost: propertyCost);
            var expectedPlayerBalance = new Money(100);

            Assert.IsTrue(mortgageBroker.PayOffMortgage(horse, property));
            Assert.AreEqual(expectedPlayerBalance, horse.Balance);
        }
    }
}
