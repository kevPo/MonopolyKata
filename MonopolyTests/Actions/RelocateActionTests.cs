using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Actions;
using Monopoly.Locations;

namespace MonopolyTests.Actions
{
    [TestClass]
    public class RelocateActionTests
    {
        [TestMethod]
        public void PlayerLocationIsSetToNewLocation()
        {
            var player = new Player("Name", 0, 0);
            var action = new RelocateAction(LocationConstants.JustVisitingLocationIndex);

            action.ProcessAction(player);

            Assert.AreEqual(LocationConstants.JustVisitingLocationIndex, player.Location);
        }
    }
}
