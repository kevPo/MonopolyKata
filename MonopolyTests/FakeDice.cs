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

        public void LoadRoll(int numberToRoll)
        {
            rollQueue.Enqueue(numberToRoll);
        }

        public void LoadRolls(IEnumerable<int> rolls)
        {
            rolls.ToList().ForEach(LoadRoll);
        }

        public int Roll()
        {
            if (rollQueue.Count() == 0)
            {
                return random.Next(2, 12);
            }

            return rollQueue.Dequeue();
        }
    }
}
