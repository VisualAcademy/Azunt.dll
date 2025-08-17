using Azunt.Utilities.Formatters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azunt.Utilities.Tests.Formatters
{
    [TestClass]
    public class PhoneNumberFormatterTests
    {
        [TestMethod]
        public void Format_ShouldReturnNone_WhenInputIsNull()
        {
            var result = PhoneNumberFormatter.Format(null!);
            Assert.AreEqual("None", result);
        }

        [TestMethod]
        public void Format_ShouldReturnNone_WhenInputIsEmpty()
        {
            var result = PhoneNumberFormatter.Format(string.Empty);
            Assert.AreEqual("None", result);
        }

        [TestMethod]
        public void Format_ShouldFormatUSPhoneNumber()
        {
            var result = PhoneNumberFormatter.Format("2014567890");
            Assert.AreEqual("(201) 456-7890", result);
        }

        [TestMethod]
        public void Format_ShouldFormatKoreanMobilePhoneNumber()
        {
            var result = PhoneNumberFormatter.Format("01012345678");
            Assert.AreEqual("010-1234-5678", result);
        }

        [TestMethod]
        public void Format_ShouldFormatSeoulPhoneNumber()
        {
            var result = PhoneNumberFormatter.Format("0212345678");
            Assert.AreEqual("02-1234-5678", result);
        }

        [TestMethod]
        public void Format_ShouldFormatKoreanLocalPhoneNumber()
        {
            var result = PhoneNumberFormatter.Format("0312345678");
            Assert.AreEqual("031-234-5678", result);
        }

        [TestMethod]
        public void Format_ShouldReturnOriginal_WhenUnknownFormat()
        {
            var result = PhoneNumberFormatter.Format("abc-def-ghij");
            Assert.AreEqual("abc-def-ghij", result);
        }

        [TestMethod]
        public void Format_ShouldIgnoreNonDigitCharacters()
        {
            var result = PhoneNumberFormatter.Format("(010) 1234-5678");
            Assert.AreEqual("010-1234-5678", result);
        }
    }
}
