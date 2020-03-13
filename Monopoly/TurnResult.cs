using System.Collections.Generic;

namespace Monopoly
{
    public class TurnResult
    {
        public int TurnOrder { get; set; }
        public string PlayerName { get; set; }
        public int StartingLocation { get; set; }
        public int EndingLocation { get; set; }
        public IList<int> Locations { get; set; }
        public int NumberOfDoubles { get; set; }
        public IList<MortgageResult> PreTurnMortgageActivity { get; set; }
        public IList<MortgageResult> PostTurnMortgageActivity { get; set; }
    }
}
