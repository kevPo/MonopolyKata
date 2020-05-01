namespace Monopoly
{
    public interface IMoveService
    {
        MoveResult MoveToLocation(int currentLocationIndex, int locationsToMove);
    }
}
