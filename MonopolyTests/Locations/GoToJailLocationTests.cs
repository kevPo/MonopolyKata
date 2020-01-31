using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.Actions;
using Monopoly.Locations;

namespace MonopolyTests.Locations
{
    [TestClass]
    public class GoToJailLocationTests
    {
        [TestMethod]
        public void ActionForGoToJailIsCorrect()
        {
            var goToJailLocation = new GoToJailLocation();

            Assert.AreEqual(typeof(NullAction), goToJailLocation.PassingAction.GetType());
            Assert.AreEqual(typeof(RelocateAction), goToJailLocation.LandingAction.GetType());
        }
    }
}
