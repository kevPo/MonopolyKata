using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.Locations;

namespace MonopolyTests.Locations
{

    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void ProcessPassingActionCallsPassingAction()
        {
            var passingAction = new FakeAction();
            var location = new Location(0, null, passingAction);

            location.ProcessPassingAction(null);

            Assert.IsTrue(passingAction.WasCalled);
        }

        [TestMethod]
        public void ProcessLandingActionCallsPassingAction()
        {
            var landingAction = new FakeAction();
            var location = new Location(0, landingAction, null);

            location.ProcessLandingAction(null);

            Assert.IsTrue(landingAction.WasCalled);
        }
    }
}
