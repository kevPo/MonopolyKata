using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class MortgageBrokerTests
    {
        private readonly IMortgageBroker mortgageBroker;

        public MortgageBrokerTests()
        {
            mortgageBroker = new MortgageBroker();
        }

        [TestMethod]
        public void PlayerCannotMortgagePropertyThatTheyDoNotOwn()
        {
            var horse = new Player("horse");
            var car = new Player("car");
            var property = new FakeProperty(owner: car);

            Assert.IsFalse(mortgageBroker.TakeOutMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerCannotMortgagePropertyThatIsNotOwned()
        {
            var horse = new Player("horse");
            var property = new FakeProperty();

            Assert.IsFalse(mortgageBroker.TakeOutMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerCannotMortgagePropertyThatIsAlreadyMortgaged()
        {
            var horse = new Player("horse");
            var property = new FakeProperty(owner: horse, isMortgaged: true);

            Assert.IsFalse(mortgageBroker.TakeOutMortgage(horse, property));
        }

        [TestMethod]
        public void PlayerSuccessfullyTakesOutAMortgageAndBalanceIncreases90PercentOfOrignalPropertyCost()
        {
            var horse = new Player("horse");
            horse.DepositMoney(new Money(200));
            var propertyCost = new Money(100);
            var property = new FakeProperty(owner: horse, cost: propertyCost);
            var expectedPlayerBalance = new Money(290);

            Assert.IsTrue(mortgageBroker.TakeOutMortgage(horse, property));
            Assert.AreEqual(expectedPlayerBalance, horse.Balance);
        }
    }
}
