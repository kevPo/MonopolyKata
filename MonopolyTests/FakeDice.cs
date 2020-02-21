using System;
using System.Collections.Generic;
using System.Linq;
using Monopoly;

namespace MonopolyTests
{
    public class FakeDice : IDice
    {
        private readonly Queue<int> rollQueue;
        private readonly Random random;

        public FakeDice()
        {
            this.rollQueue = new Queue<int>();
            this.random = new Random();
        }

        public int LastRoll { get; private set; }

        public void LoadRoll(int numberToRoll)
        {
            rollQueue.Enqueue(numberToRoll);
        }

        public int Roll()
        {
            if (rollQueue.Count() == 0)
            {
                LastRoll = random.Next(2, 12);
                return LastRoll;
            }

            LastRoll = rollQueue.Dequeue();
            return LastRoll;
        }
    }
}
