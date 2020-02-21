using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Locations;

namespace MonopolyTests
{
    [TestClass]
    public class BoardTests
    {
        private Board board;

        public BoardTests()
        {
            var dice = new FakeDice();
            board = new Board(dice);
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

            Assert.AreEqual(7, result.CurrentLocation.LocationIndex);
        }

        [TestMethod]
        public void CalculateNewLocationFrom39With6LocationsToMoveReturns5()
        {
            var result = board.MoveToLocation(39, 6);

            Assert.AreEqual(5, result.CurrentLocation.LocationIndex);
        }

        [TestMethod]
        public void PlayerOwnsPropertyGroupReturnsFalseWhenPlayerOwnsNoneOfPropertyGroup()
        {
            var player = new Player("horse");

            var result = board.PlayerOwnsPropertyGroup(player, LocationConstants.DarkBluePropertyGroup);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PlayerOwnsPropertyGroupReturnsFalseWhenPlayerOwnsSomeOfPropertyGroup()
        {
            var player = new Player("horse");
            (board.Locations.ElementAt(LocationConstants.ParkPlaceIndex) as IProperty).TransitionOwnership(player);

            var result = board.PlayerOwnsPropertyGroup(player, LocationConstants.DarkBluePropertyGroup);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PlayerOwnsPropertyGroupReturnsTrueWhenPlayerOwnsAllOfPropertyGroup()
        {
            var player = new Player("horse");
            (board.Locations.ElementAt(LocationConstants.ParkPlaceIndex) as IProperty).TransitionOwnership(player);
            (board.Locations.ElementAt(LocationConstants.BoardwalkIndex) as IProperty).TransitionOwnership(player);

            var result = board.PlayerOwnsPropertyGroup(player, LocationConstants.DarkBluePropertyGroup);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NumberOfRailRoadsOwnedByPlayerReturnsZeroWhenPlayerDoesNotOwnAny()
        {
            var expected = 0;
            var player = new Player("horse");
            
            var actual = board.NumberOfRailRoadsOwnedByPlayer(player);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberOfRailRoadsOwnedByPlayerReturnsThreeWhenPlayerOwnsThree()
        {
            var expected = 3;
            var player = new Player("horse");
            (board.Locations.ElementAt(LocationConstants.ReadingRailroadIndex) as IProperty).TransitionOwnership(player);
            (board.Locations.ElementAt(LocationConstants.PennsylvaniaRailroadIndex) as IProperty).TransitionOwnership(player);
            (board.Locations.ElementAt(LocationConstants.BAndORailroadIndex) as IProperty).TransitionOwnership(player);
            
            var actual = board.NumberOfRailRoadsOwnedByPlayer(player);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberOfUtilitiesOwnedReturnsZeroWhenNoneAreOwned()
        {
            var expected = 0;
            
            var actual = board.NumberOfUtilitiesOwned();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NumberOfUtilitiesOwnedReturnsTwoWhenTwoAreOwned()
        {
            var expected = 2;
            var player = new Player("horse");
            (board.Locations.ElementAt(LocationConstants.WaterWorksIndex) as IProperty).TransitionOwnership(player);
            (board.Locations.ElementAt(LocationConstants.ElectricCompanyIndex) as IProperty).TransitionOwnership(player);

            var actual = board.NumberOfUtilitiesOwned();

            Assert.AreEqual(expected, actual);
        }
    }
}
