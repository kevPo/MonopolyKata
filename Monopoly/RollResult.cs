using System;

namespace Monopoly
{
    public class RollResult : Tuple<int, int>
    {
        public RollResult((int, int) tuple)
            : base(tuple.Item1, tuple.Item2)
        {
        }

        public RollResult(int roll1, int roll2)
            : base(roll1, roll2)
        {
        }

        public int Total => Item1 + Item2;
        public bool IsDoubles => Item1 == Item2;
    }
}
