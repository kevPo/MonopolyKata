using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.Cards;

namespace MonopolyTests.Cards
{
    [TestClass]
    public class CardDeckTests
    {
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Creation_ThrowsArgumentException_WhenNoCardsArePassedIn()
        {
            _ = new CardDeck(Enumerable.Empty<ICard>());
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Creation_ThrowsArgumentNullException_WhenGivenNull()
        {
            _ = new CardDeck(null);
        }

        [TestMethod]
        public void GetTopCard_ReturnsTopCard()
        {
            var topCard = new FakeCard();
            var bottomCard = new FakeCard();
            var cardDeck = new CardDeck(new[] { topCard, bottomCard });
            
            var card = cardDeck.GetTopCard();

            Assert.AreEqual(topCard, card);
        }

        [TestMethod]
        public void GetBottomCard_ReturnsBottomCard()
        {
            var topCard = new FakeCard();
            var bottomCard = new FakeCard();
            var cardDeck = new CardDeck(new[] { topCard, bottomCard });

            var card = cardDeck.GetBottomCard();

            Assert.AreEqual(bottomCard, card);
        }

        [TestMethod]
        public void PutCardOnBottom_RemovesTopCardFromTheTop()
        {
            var card1 = new FakeCard();
            var card2 = new FakeCard();
            var cardDeck = new CardDeck(new[] { card1, card2 });

            cardDeck.PutTopCardOnBottom();
            var card = cardDeck.GetBottomCard();

            Assert.AreEqual(card1, card);
        }
    }
}
