using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    
    [TestClass]
    public class MoneyServicesTests
    {
        [TestMethod]
        public void AddMoneyReturnsCorrectAmount()
        {
            var amount1 = 500;
            var amount2 = 250;
            var expectedAmount = 500 + 250;

            var result = new Money(amount1).Add(new Money(amount2));

            Assert.AreEqual(expectedAmount, result.Amount);
        }

        [TestMethod]
        public void RemoveMoneyReturnsCorrectAmount()
        {
            var amount1 = 500;
            var amount2 = 250;
            var expectedAmount = 500 - 250;

            var result = new Money(amount1).Remove(new Money(amount2));

            Assert.AreEqual(expectedAmount, result.Amount);
        }

        [TestMethod]
        public void ApplyRateReturnsCorrectAmount()
        {
            var rate = .9;
            var amount1 = 192;
            var expectedAmount = Convert.ToInt32(Math.Floor(amount1 * rate));

            var result = new Money(amount1).ApplyRate(rate);

            Assert.AreEqual(expectedAmount, result.Amount);
        }
    }
}
