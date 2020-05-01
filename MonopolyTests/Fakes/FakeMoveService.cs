using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakeMoveService : IMoveService
    {
        public MoveResult MoveToLocation(int currentLocationIndex, int locationsToMove)
        {
            return new MoveResult();
        }
    }
}
