using Azunt.Networking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azunt.Networking.Tests
{
    [TestClass]
    public class IpAddressUtilityTests
    {
        [TestMethod]
        public void IsIpInRange_ShouldReturnTrue_WhenIpIsInRange()
        {
            Assert.IsTrue(IpAddressUtility.IsIpInRange("192.168.0.100", "192.168.0.1", "192.168.0.255"));
        }

        [TestMethod]
        public void IsIpInRange_ShouldReturnFalse_WhenIpIsBelowRange()
        {
            Assert.IsFalse(IpAddressUtility.IsIpInRange("192.168.0.0", "192.168.0.1", "192.168.0.255"));
        }

        [TestMethod]
        public void IsIpInRange_ShouldReturnFalse_WhenIpIsAboveRange()
        {
            Assert.IsFalse(IpAddressUtility.IsIpInRange("192.168.1.0", "192.168.0.1", "192.168.0.255"));
        }

        [TestMethod]
        public void IsIpInRange_ShouldReturnTrue_WhenIpIsStartOfRange()
        {
            Assert.IsTrue(IpAddressUtility.IsIpInRange("192.168.0.1", "192.168.0.1", "192.168.0.255"));
        }

        [TestMethod]
        public void IsIpInRange_ShouldReturnTrue_WhenIpIsEndOfRange()
        {
            Assert.IsTrue(IpAddressUtility.IsIpInRange("192.168.0.255", "192.168.0.1", "192.168.0.255"));
        }
    }
}