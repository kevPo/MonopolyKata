using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Actions;
using MonopolyTests.Cards;

namespace MonopolyTests.Actions
{
    [TestClass]
    public class PickupCardActionTests
    {
        private readonly Money stimulusMoney = new Money(2000);

        [TestMethod]
        public void ProcessAction_PlaysCardForPlayer()
        {
            var stimulusCard = new FakeStimulusCard(stimulusMoney);
            var cardDeck = new FakeCardDeck(stimulusCard);
            var action = new PickupCardAction(cardDeck);
            var player = new Player("Fake");

            action.ProcessAction(player);

            Assert.AreEqual(stimulusMoney, player.Balance);
        }
    }
}
