using Microsoft.VisualStudio.TestTools.UnitTesting;
using Azunt.Utilities.Validation;

namespace Azunt.Utilities.Tests.Validation
{
    [TestClass]
    public class PasswordValidatorTests
    {
        [TestMethod]
        public void ValidPassword_ReturnsTrue_ForSecurePassword()
        {
            Assert.IsTrue(PasswordValidator.IsValid("Aa1@abcd"));
            Assert.IsTrue(PasswordValidator.IsValid("Zz9!Xx9@"));
        }

        [TestMethod]
        public void ValidPassword_ReturnsFalse_ForTooShort()
        {
            Assert.IsFalse(PasswordValidator.IsValid("Aa1@"));
        }

        [TestMethod]
        public void ValidPassword_ReturnsFalse_IfMissingRequirements()
        {
            Assert.IsFalse(PasswordValidator.IsValid("abcdefgh"));     // No upper, digit, special
            Assert.IsFalse(PasswordValidator.IsValid("ABCDEFGH"));     // No lower, digit, special
            Assert.IsFalse(PasswordValidator.IsValid("abcdEFGH"));     // No digit, special
            Assert.IsFalse(PasswordValidator.IsValid("Abcd1234"));     // No special
        }

        [TestMethod]
        public void ValidPassword_ReturnsFalse_ForNullOrEmpty()
        {
            Assert.IsFalse(PasswordValidator.IsValid(null!));
            Assert.IsFalse(PasswordValidator.IsValid(""));
        }
    }
}
