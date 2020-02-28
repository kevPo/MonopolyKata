namespace Monopoly
{
    public class RollResult
    {
        private readonly int roll1;
        private readonly int roll2;

        public RollResult(int roll1, int roll2)
        {
            this.roll1 = roll1;
            this.roll2 = roll2;
        }

        public int Total => roll1 + roll2;
        public bool IsDoubles => roll1 == roll2;
    }
}
