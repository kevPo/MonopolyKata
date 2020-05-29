using System.Collections.Generic;
using System.Linq;
using Monopoly.Actions;
using Monopoly.Cards;

namespace Monopoly.Locations.Factories
{
    public class DeckFactory : IDeckFactory
    {
        private readonly IEnumerable<ICard> cards = new[]
        {
            new ActionCard(new NullAction()),
            new ActionCard(new NullAction()),
            new ActionCard(new NullAction()),
            new ActionCard(new NullAction()),
        };

        public ICardDeck CreateChanceDeck()
        {
            return new CardDeck(cards);
        }

        public ICardDeck CreateCommunityChestDeck()
        {
            return new CardDeck(cards);
        }
    }
}
