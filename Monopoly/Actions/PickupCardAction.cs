using Monopoly.Cards;

namespace Monopoly.Actions
{
    public class PickupCardAction : IAction
    {
        private readonly ICardDeck cardDeck;

        public PickupCardAction(ICardDeck cardDeck)
        {
            this.cardDeck = cardDeck;
        }

        public void ProcessAction(IPlayer player)
        {
            cardDeck.DrawCard().Play(player);
        }
    }
}
