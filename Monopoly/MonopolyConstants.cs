namespace Monopoly
{
    public static class MonopolyConstants
    {
        public static readonly Money NoMoney = new Money(0);
        public static readonly Money GoPayoutAmount = new Money(200);
        public static readonly Money IncomeTaxMaximumAmount = new Money(200);
        public static readonly Money LuxuryTaxAmount = new Money(75);
        public const int IncomeTaxRate = 10;
    }
}
