using Monopoly.Cards;

namespace Monopoly.Locations.Factories
{
    public interface IDeckFactory
    {
        ICardDeck CreateChanceDeck();
        ICardDeck CreateCommunityChestDeck();
    }
}
