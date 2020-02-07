using Monopoly.Locations;

namespace Monopoly.Actions
{
    public class RelocateAction : IAction
    {
        private readonly int newLocationIndex;

        public RelocateAction(int newLocationIndex)
        {
            this.newLocationIndex = newLocationIndex;
        }

        public void ProcessAction(IPlayer player, ILocation location)
        {
            player.Location = newLocationIndex;
        }
    }
}
