using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class BoardTests
    {
        private Board board;

        public BoardTests()
        {
            board = new Board();
        }

        [TestMethod]
        public void BoardHas40Locations()
        {
           Assert.AreEqual(40, board.Locations.Count());
        }

        [TestMethod]
        public void MoveNewPlayer7LocationsReturns7()
        {
            var result = board.MoveToLocation(0, 7);

            Assert.AreEqual(7, result.CurrentLocation);
        }

        [TestMethod]
        public void CalculateNewLocationFrom39With6LocationsToMoveReturns5()
        {
            var result = board.MoveToLocation(39, 6);

            Assert.AreEqual(5, result.CurrentLocation);
        }
    }
}
