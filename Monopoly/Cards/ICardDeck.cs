namespace Monopoly.Cards
{
    public interface ICardDeck
    {
        ICard GetTopCard();
        ICard GetBottomCard();
        void PutTopCardOnBottom();
    }
}
