using Monopoly.Locations;

namespace Monopoly.Actions
{
    public class GoToJailAction : IAction
    {
        public void ProcessAction(IPlayer player)
        {
            player.GoToJail();
        }
    }
}
