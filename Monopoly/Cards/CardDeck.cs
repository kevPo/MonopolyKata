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
            if (!cards.Any())
            {
                throw new ArgumentException("Gotta have cards!");
            }

            this.cards = cards ?? throw new ArgumentNullException(nameof(cards));
        }

        public ICard GetTopCard()
        {
            return cards.First();
        }

        public ICard GetBottomCard()
        {
            return cards.Last();
        }

        public void PutTopCardOnBottom()
        {
            cards = cards.Skip(1).Append(GetTopCard());
        }
    }
}
