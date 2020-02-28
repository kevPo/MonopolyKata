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

        public void LoadRoll(int roll1, int roll2)
        {
            rollQueue.Enqueue(new RollResult(roll1, roll2));
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
