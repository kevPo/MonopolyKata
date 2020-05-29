using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Cards;
using MonopolyTests.Fakes;

namespace MonopolyTests.Cards
{
    [TestClass]
    public class ActionCardTests
    {
        [TestMethod]
        public void ActionCardCallsInternalActionWithPlayer()
        {
            var player = new Player("Fake");
            var action = new FakeAction();
            var card = new ActionCard(action);

            card.Play(player);

            Assert.IsTrue(action.WasCalledWith(player));
        }
    }
}
