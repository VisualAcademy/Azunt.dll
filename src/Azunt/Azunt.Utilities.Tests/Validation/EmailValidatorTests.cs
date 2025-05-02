using Microsoft.VisualStudio.TestTools.UnitTesting;
using Azunt.Utilities.Validation;

namespace Azunt.Utilities.Tests.Validation
{
    [TestClass]
    public class EmailValidatorTests
    {
        [TestMethod]
        public void ValidEmail_ReturnsTrue_ForCorrectFormat()
        {
            Assert.IsTrue(EmailValidator.IsValid("user@example.com"));
            Assert.IsTrue(EmailValidator.IsValid("john.doe@company.org"));
        }

        [TestMethod]
        public void ValidEmail_ReturnsFalse_ForIncorrectFormat()
        {
            Assert.IsFalse(EmailValidator.IsValid("userexample.com"));
            Assert.IsFalse(EmailValidator.IsValid("user@.com"));
            Assert.IsFalse(EmailValidator.IsValid("user@com"));
            Assert.IsFalse(EmailValidator.IsValid("user@company."));
        }

        [TestMethod]
        public void ValidEmail_ReturnsFalse_ForNullOrEmpty()
        {
            Assert.IsFalse(EmailValidator.IsValid(null));
            Assert.IsFalse(EmailValidator.IsValid(""));
        }
    }
}
