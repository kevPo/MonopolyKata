using Monopoly.Locations;

namespace Monopoly.Actions
{
    public class GoToJailAction : IAction
    {
        public void ProcessAction(IPlayer player)
        {
            player.Location = LocationConstants.JailIndex;
            player.IsInJail = true;
        }
    }
}
