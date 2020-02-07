using Monopoly;
using Monopoly.Actions;

namespace MonopolyTests
{
    public class FakeAction : IAction
    {
        public bool WasCalled { get; private set; }

        public void ProcessAction(IPlayer player)
        {
            WasCalled = true;
        }
    }
}
