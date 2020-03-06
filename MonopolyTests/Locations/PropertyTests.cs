using Microsoft.VisualStudio.TestTools.UnitTesting;
using Monopoly.Locations;

namespace MonopolyTests.Locations
{
    [TestClass]
    public class PropertyTests
    {
        private IProperty property;

        public PropertyTests()
        {
            property = new Property(LocationConstants.MediterraneanAveIndex, LocationConstants.PurplePropertyGroup, null, LocationConstants.MediterraneanAveCost, LocationConstants.MediterraneanAveRent);
        }

        [TestMethod]
        public void MortgagePropertySetsIsMortgagedToTrue()
        {
            property.MortgageProperty();

            Assert.IsTrue(property.IsMortgaged);
        }

        [TestMethod]
        public void UnmortgagePropertySetsIsMortgagedToFalse()
        {
            property.UnmortgageProperty();

            Assert.IsFalse(property.IsMortgaged);
        }
    }
}
