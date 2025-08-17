using Microsoft.VisualStudio.TestTools.UnitTesting;
using Azunt.Utilities.Validation;

namespace Azunt.Utilities.Tests.Validation
{
    [TestClass]
    public class UsernameValidatorTests
    {
        [TestMethod]
        public void ValidUsername_ReturnsTrue_ForValidInput()
        {
            Assert.IsTrue(UsernameValidator.IsValid("john_doe123"));
            Assert.IsTrue(UsernameValidator.IsValid("User01"));
        }

        [TestMethod]
        public void ValidUsername_ReturnsFalse_ForInvalidCharacters()
        {
            Assert.IsFalse(UsernameValidator.IsValid("john/doe"));
            Assert.IsFalse(UsernameValidator.IsValid("john doe")); // space
            Assert.IsFalse(UsernameValidator.IsValid("john+doe"));

            Assert.IsTrue(UsernameValidator.IsValid("john@doe"));
        }

        [TestMethod]
        public void ValidUsername_ReturnsFalse_ForNullOrEmpty()
        {
            Assert.IsFalse(UsernameValidator.IsValid(null!));
            Assert.IsFalse(UsernameValidator.IsValid(""));
            Assert.IsFalse(UsernameValidator.IsValid(" "));
        }
    }
}
