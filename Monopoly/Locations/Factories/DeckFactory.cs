using System.Collections.Generic;
using Monopoly.Actions;
using Monopoly.Cards;

namespace Monopoly.Locations.Factories
{
    public class DeckFactory : IDeckFactory
    {
        private readonly IEnumerable<ICard> chanceCards = new[]
        {
            new ActionCard(new NullAction()),
            new ActionCard(new NullAction()),
            new ActionCard(new NullAction()),
            new ActionCard(new NullAction()),
        };
        private readonly IEnumerable<ICard> communityChestCards = new[]
        {
            new ActionCard(new DepositAction(new Money(100))),
            new ActionCard(new GoToJailAction()),
            new ActionCard(new DepositAction(new Money(45))),
            new ActionCard(new WithdrawAction(new Money(100))),
        };

        public ICardDeck CreateChanceDeck()
        {
            return new CardDeck(chanceCards);
        }

        public ICardDeck CreateCommunityChestDeck()
        {
            return new CardDeck(communityChestCards);
        }
    }
}
