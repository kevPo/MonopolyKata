using Monopoly.Actions;

namespace Monopoly.Cards
{
    public class ActionCard : ICard
    {
        private readonly IAction action;

        public ActionCard(IAction action)
        {
            this.action = action;
        }

        public void Play(IPlayer player)
        {
            action.ProcessAction(player);
        }
    }
}
