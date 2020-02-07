using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Actions;
using Monopoly.Locations;

namespace MonopolyTests.Locations
{
    public class FakeAction : IAction
    {
        public bool WasCalled { get; private set; }

        public void ProcessAction(IPlayer player, ILocation location)
        {
            WasCalled = true;
        }
    }

    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void ProcessPassingActionCallsPassingAction()
        {
            var passingAction = new FakeAction();
            var location = new Location(0, passingAction: passingAction);

            location.ProcessPassingAction(null);

            Assert.IsTrue(passingAction.WasCalled);
        }

        [TestMethod]
        public void ProcessLandingActionCallsPassingAction()
        {
            var landingAction = new FakeAction();
            var location = new Location(0, landingAction: landingAction);

            location.ProcessLandingAction(null);

            Assert.IsTrue(landingAction.WasCalled);
        }
    }
}
