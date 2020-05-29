using System;
using System.Collections.Generic;
using System.Linq;

namespace Monopoly.Cards
{
    public class CardDeck : ICardDeck
    {
        private IEnumerable<ICard> cards;

        public CardDeck(IEnumerable<ICard> cards)
        {
            this.cards = cards ?? throw new ArgumentNullException(nameof(cards));

            if (!this.cards.Any())
            {
                throw new ArgumentException("Gotta have cards!");
            }
        }

        public ICard DrawCard()
        {
            var topCard = cards.First();
            cards = cards.Skip(1).Append(topCard);

            return topCard;
        }

        public ICard GetBottomCard()
        {
            return cards.Last();
        }
    }
}
