using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class RollResultTests
    {
        [TestMethod]
        public void TotalReturnsTheSumOfBothRolls()
        {
            var expectedTotal = 9;
            var rollResult = new RollResult(5, 4);

            Assert.AreEqual(expectedTotal, rollResult.Total);
        }

        [TestMethod]
        public void IsDoublesReturnsTrueWhenRollsAreEqual()
        {
            var roll = new RollResult(5, 5);
            Assert.IsTrue(roll.IsDoubles);
        }

        [TestMethod]
        public void IsDoublesReturnsFalseWhenRollsAreNotEqual()
        {
            var roll = new RollResult(5, 4);
            Assert.IsFalse(roll.IsDoubles);
        }
    }
}
