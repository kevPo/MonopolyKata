using Monopoly;
using Monopoly.Cards;

namespace MonopolyTests.Cards
{
    public class FakeCard : ICard
    {
        public IPlayer LastPlayerPlayed { get; set; }

        public void Play(IPlayer player)
        {
            LastPlayerPlayed = player;
        }
    }
}
