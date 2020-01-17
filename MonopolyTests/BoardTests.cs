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
        public void MoveNewPlayer7LocationsReturns7()
        {
            var board = new Board();

            Assert.AreEqual(7, board.MovePlayer("horse", 7));
        }

        [TestMethod]
        public void CalculateNewLocationFrom39With6LocationsToMoveReturns5()
        {
            var board = new Board();
            var horse = "horse";
            board.MovePlayer(horse, 39);

            var newLocation = board.MovePlayer(horse, 6);

            Assert.AreEqual(5, newLocation);
        }
    }
}
