using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly;
using Monopoly.Locations;
using Monopoly.Mortgage;
using MonopolyTests.Fakes;

namespace MonopolyTests
{
    [TestClass]
    public class MortgageServiceTests
    {
        private IBoard board;
        private IPlayer player;
        private IMortgageBroker mortgageBroker;

        public MortgageServiceTests()
        {
            board = new FakeBoard();
            player = new Player("horse");
            mortgageBroker = new MortgageBroker();
        }

        [TestMethod]
        public void ProcessMortgageTransactionsMortgagesPropertyWhenAdvisorSaysTo()
        {
            var mortgageService = BuildMortgageService(alwaysMortgage: true);
            var propertiesToMortgage = board.Locations.OfType<IProperty>().Take(3);
            propertiesToMortgage.ForEach(p => p.TransitionOwnership(player));

            var mortgageResult = mortgageService.ProcessMortgageTransactions(player);

            Assert.AreEqual(3, mortgageResult.MortgagedProperties.Count());
            Assert.IsTrue(mortgageResult.MortgagedProperties.All(p => p.IsMortgaged));
            Assert.IsFalse(mortgageResult.PaidOffProperties.Any());
        }

        [TestMethod]
        public void ProcessMortgageTransactionsPaysOffMortgagesWhenAdvisorSaysTo()
        {
            var mortgageService = BuildMortgageService(alwaysPayOff: true);
            var propertiesToMortgage = board.Locations.OfType<IProperty>().Take(3);
            propertiesToMortgage.ForEach(p => p.TransitionOwnership(player));
            propertiesToMortgage.ForEach(p => mortgageBroker.TakeOutMortgage(player, p));

            var mortgageResult = mortgageService.ProcessMortgageTransactions(player);

            Assert.AreEqual(3, mortgageResult.PaidOffProperties.Count());
            Assert.IsFalse(mortgageResult.MortgagedProperties.Any(p => p.IsMortgaged));
            Assert.IsFalse(mortgageResult.MortgagedProperties.Any());
        }

        private IMortgageService BuildMortgageService(bool alwaysMortgage = false, bool alwaysPayOff = false)
        {
            var mortgageAdvisor = new FakeMortgageAdvisor(alwaysMortgage, alwaysPayOff);
            
            return new MortgageService(board, mortgageAdvisor, mortgageBroker);
        }
    }
}
