using Monopoly;
using Monopoly.Locations;
using Monopoly.Mortgage;

namespace MonopolyTests.Fakes
{
    public class FakeMortgageAdvisor : IMortgageAdvisor
    {
        private bool alwaysMortgage;
        private bool alwaysPayOff;

        public FakeMortgageAdvisor(bool alwaysMortgage = false, bool alwaysPayOff = false)
        {
            this.alwaysMortgage = alwaysMortgage;
            this.alwaysPayOff = alwaysPayOff;
        }

        public bool PlayerShouldMortgageProperty(IPlayer player, IProperty property)
        {
            return alwaysMortgage;
        }

        public bool PlayerShouldPayOffMortgage(IPlayer player, IProperty property)
        {
            return alwaysPayOff;
        }
    }
}
