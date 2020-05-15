using System;
using Monopoly;
using Monopoly.Cards;

namespace MonopolyTests.Cards
{
    public class FakeCard : ICard
    {
        public void Play(IPlayer play)
        {
            throw new NotImplementedException();
        }
    }
}
