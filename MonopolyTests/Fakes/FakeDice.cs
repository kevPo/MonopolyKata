using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly;

namespace MonopolyTests.Fakes
{
    public class FakeDice : IDice
    {
        private readonly Queue<RollResult> rollQueue;
        private readonly Random random;

        public FakeDice()
        {
            rollQueue = new Queue<RollResult>();
            random = new Random();
        }

        public RollResult LastRoll { get; private set; }

        public void LoadRoll(RollResult rollResult)
        {
            rollQueue.Enqueue(rollResult);
        }

        public void LoadRoll(int roll1, int roll2)
        {
            rollQueue.Enqueue(new RollResult(roll1, roll2));
        }

        public RollResult Roll()
        {
            if (!rollQueue.Any())
            {
                LastRoll = new RollResult(random.Next(1, 6), random.Next(1, 6));
                return LastRoll;
            }

            LastRoll = rollQueue.Dequeue();

            return LastRoll;
        }
    }
}
