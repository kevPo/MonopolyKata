using Monopoly;
using Monopoly.Cards;

namespace MonopolyTests.Cards
{
    public class FakeStimulusCard : ICard
    {
        private readonly Money money;

        public FakeStimulusCard()
        {
            money = new Money(200);
        }

        public FakeStimulusCard(Money money)
        {
            this.money = money;
        }

        public void Play(IPlayer player)
        {
            player.DepositMoney(money);
        }
    }
}
