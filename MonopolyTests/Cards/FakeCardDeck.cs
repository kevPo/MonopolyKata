using Monopoly.Cards;

namespace MonopolyTests.Cards
{
    public class FakeCardDeck : ICardDeck
    {
        private readonly ICard card;

        public FakeCardDeck(ICard card)
        {
            this.card = card;
        }

        public ICard GetBottomCard()
        {
            return card;
        }

        public ICard DrawCard()
        {
            return card;
        }
    }
}
