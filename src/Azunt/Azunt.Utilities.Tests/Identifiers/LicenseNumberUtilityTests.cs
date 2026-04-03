using Azunt.Utilities.Identifiers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azunt.Utilities.Tests.Identifiers
{
    [TestClass]
    public class LicenseNumberUtilityTests
    {
        [TestMethod]
        public void GetNext_ShouldIncrementPlainNumber()
        {
            var result = LicenseNumberUtility.GetNext("1234");

            Assert.AreEqual("1235", result);
        }

        [TestMethod]
        public void GetNext_ShouldIncrementLicenseNumberWithPrefix()
        {
            var result = LicenseNumberUtility.GetNext("LN-1234");

            Assert.AreEqual("LN-1235", result);
        }

        [TestMethod]
        public void GetNext_ShouldIncrementLicenseNumberWithYearAndPrefix()
        {
            var result = LicenseNumberUtility.GetNext("2026-LN-1234");

            Assert.AreEqual("2026-LN-1235", result);
        }

        [TestMethod]
        public void GetNext_ShouldPreserveLeadingZeros_WhenPossible()
        {
            var result = LicenseNumberUtility.GetNext("LN-0099");

            Assert.AreEqual("LN-0100", result);
        }

        [TestMethod]
        public void GetNext_ShouldIncreaseDigitLength_WhenNeeded()
        {
            var result = LicenseNumberUtility.GetNext("LN-9999");

            Assert.AreEqual("LN-10000", result);
        }

        [TestMethod]
        public void GetNext_ShouldReturnEmpty_WhenInputIsNull()
        {
            var result = LicenseNumberUtility.GetNext(null!);

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetNext_ShouldReturnEmpty_WhenInputIsEmpty()
        {
            var result = LicenseNumberUtility.GetNext(string.Empty);

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetNext_ShouldReturnEmpty_WhenInputIsWhitespace()
        {
            var result = LicenseNumberUtility.GetNext("   ");

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetNext_ShouldReturnEmpty_WhenInputDoesNotEndWithDigits()
        {
            var result = LicenseNumberUtility.GetNext("LN-ABCD");

            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void GetNext_ShouldReturnEmpty_WhenDigitsAreNotAtTheEnd()
        {
            var result = LicenseNumberUtility.GetNext("1234-LN");

            Assert.AreEqual(string.Empty, result);
        }
    }
}