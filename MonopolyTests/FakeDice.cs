using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly;

namespace MonopolyTests
{
    public class FakeDice : IDice
    {
        private readonly Queue<RollResult> rollQueue;
        private readonly Random random;

        public FakeDice()
        {
            this.rollQueue = new Queue<RollResult>();
            this.random = new Random();
        }

        public RollResult LastRoll { get; private set; }


        public void LoadRoll(RollResult rollResult)
        {
            rollQueue.Enqueue(rollResult);
        }

        public void LoadRoll((int, int) rollResult)
        {
            rollQueue.Enqueue(new RollResult(rollResult.Item1, rollResult.Item2));
        }

        public RollResult Roll()
        {
            if (rollQueue.Count() == 0)
            {
                LastRoll = new RollResult(random.Next(1, 6), random.Next(1, 6));
                return LastRoll;
            }

            LastRoll = rollQueue.Dequeue();
            return LastRoll;
        }
    }
}
