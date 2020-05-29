using Monopoly;
using Monopoly.Actions;

namespace MonopolyTests.Fakes
{
    public class FakeAction : IAction
    {
        public bool WasCalled { get; private set; }
        public IPlayer LastPlayerProcessed { get; private set; }

        public void ProcessAction(IPlayer player)
        {
            WasCalled = true;
            LastPlayerProcessed = player;
        }

        public bool WasCalledWith(IPlayer player)
        {
            return WasCalled && LastPlayerProcessed == player;
        }
    }
}
