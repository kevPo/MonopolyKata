using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Actions;
using Monopoly.Locations;

namespace MonopolyTests.Actions
{
    [TestClass]
    public class GoToJailActionTests
    {
        [TestMethod]
        public void PlayerLocationIsSetToJailLocation()
        {
            var player = new Player("Name");
            var action = new GoToJailAction();

            action.ProcessAction(player);

            Assert.AreEqual(LocationConstants.JailIndex, player.Location);
        }

        [TestMethod]
        public void PlayerIsInJail()
        {
            var player = new Player("Name");
            var action = new GoToJailAction();

            action.ProcessAction(player);

            Assert.IsTrue(player.IsInJail);
        }
    }
}
