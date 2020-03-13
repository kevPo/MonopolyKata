using System.Collections.Generic;
using System.Linq;
using Monopoly.Locations;

namespace Monopoly
{
    public class MortgageService : IMortgageService
    {
        private readonly IBoard board;
        private readonly IMortgageAdvisor mortgageAdvisor;
        private readonly IMortgageBroker mortgageBroker;

        public MortgageService(IBoard board, IMortgageAdvisor mortgageAdvisor, IMortgageBroker mortgageBroker)
        {
            this.board = board;
            this.mortgageAdvisor = mortgageAdvisor;
            this.mortgageBroker = mortgageBroker;
        }

        public MortgageResult ProcessMortgageTransactions(IPlayer player)
        {
            var properties = GetPropertiesOwnedByPlayer(player);

            var propertiesToMortgage = properties.Where(p => mortgageAdvisor.PlayerShouldMortgageProperty(player, p));
            propertiesToMortgage.ForEach(p => mortgageBroker.TakeOutMortgage(player, p));

            var propertiesToPayOff = properties.Where(p => mortgageAdvisor.PlayerShouldPayOffMortgage(player, p));
            propertiesToPayOff.ForEach(p => mortgageBroker.PayOffMortgage(player, p));

            return new MortgageResult { MortgagedProperties = propertiesToMortgage, PaidOffProperties = propertiesToPayOff };
        }

        private IEnumerable<IProperty> GetPropertiesOwnedByPlayer(IPlayer player)
        {
            return board.Locations.OfType<IProperty>()
                .Where(p => p.Owner == player);
        }
    }
}
