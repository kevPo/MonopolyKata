using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakeBailAdvisor : IBailAdvisor
    {
        public bool ShouldPayBail { get; set; }

        public bool PlayerShouldPayBail(IPlayer player)
        {
            return ShouldPayBail;
        }
    }
}
