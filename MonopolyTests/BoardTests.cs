using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;

namespace MonopolyTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void BoardHas40Locations()
        {
           var board = new Board();

           Assert.AreEqual(40, board.Locations.Count());
        }

        [TestMethod]
        public void CalculateNewLocationFrom0With7LocationsToMoveReturns7()
        {
            var board = new Board();

            Assert.AreEqual(7, board.CalculateNewLocation(0, 7));
        }

        [TestMethod]
        public void CalculateNewLocationFrom39With6LocationsToMoveReturns5()
        {
            var board = new Board();

            Assert.AreEqual(5, board.CalculateNewLocation(39, 6));
        }
    }
}
