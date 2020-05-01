using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using MonopolyTests.Fakes;

namespace MonopolyTests
{
    [TestClass]
    public class MoveServiceTests
    {
        private MoveService moveService;

        public MoveServiceTests()
        {
            var fakeBoard = new FakeBoard();
            moveService = new MoveService(fakeBoard);
        }

        [TestMethod]
        public void MoveNewPlayer7LocationsReturns7()
        {
            var result = moveService.MoveToLocation(0, 7);

            Assert.AreEqual(7, result.CurrentLocation.LocationIndex);
        }

        [TestMethod]
        public void CalculateNewLocationFrom39With6LocationsToMoveReturns5()
        {
            var result = moveService.MoveToLocation(39, 6);

            Assert.AreEqual(5, result.CurrentLocation.LocationIndex);
        }
    }
}
