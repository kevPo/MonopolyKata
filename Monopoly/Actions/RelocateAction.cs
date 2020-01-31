namespace Monopoly.Actions
{
    public class RelocateAction : IAction
    {
        private readonly int newLocationIndex;

        public RelocateAction(int newLocationIndex)
        {
            this.newLocationIndex = newLocationIndex;
        }

        public void ProcessAction(IPlayer player)
        {
            player.Location = newLocationIndex;
        }
    }
}
