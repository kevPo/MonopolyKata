using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Actions;
using MonopolyTests.Cards;

namespace MonopolyTests.Actions
{
    [TestClass]
    public class PickupCardActionTests
    {
        [TestMethod]
        public void ProcessAction_PlaysCardForPlayer()
        {
            var card = new FakeCard();
            var cardDeck = new FakeCardDeck(card);
            var action = new PickupCardAction(cardDeck);
            var player = new Player("Fake");

            action.ProcessAction(player);

            Assert.AreEqual(card.LastPlayerPlayed, player);
        }
    }
}
