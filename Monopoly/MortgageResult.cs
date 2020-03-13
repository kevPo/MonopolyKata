using System.Collections.Generic;
using Monopoly.Locations;

namespace Monopoly
{
    public class MortgageResult
    {
        public IEnumerable<IProperty> MortgagedProperties { get; set; }
        public IEnumerable<IProperty> PaidOffProperties { get; set; }
    }
}
