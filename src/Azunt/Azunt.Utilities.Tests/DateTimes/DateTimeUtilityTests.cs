using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Azunt.Utilities.DateTimes;

namespace Azunt.Utilities.Tests.DateTimes
{
    [TestClass]
    public class DateTimeUtilityTests
    {
        [TestMethod]
        public void ShowTimeOrDate_ShouldReturnTime_WhenToday()
        {
            // Arrange
            var now = DateTime.Now;

            // Act
            var result = DateTimeUtility.ShowTimeOrDate(now);

            // Assert
            Assert.IsTrue(result.Contains(":"));
        }

        [TestMethod]
        public void ShowTimeOrDate_ShouldReturnDate_WhenNotToday()
        {
            // Arrange
            var past = DateTime.Now.AddDays(-1);

            // Act
            var result = DateTimeUtility.ShowTimeOrDate(past);

            // Assert
            Assert.IsTrue(result.Contains("-"));
        }

        [TestMethod]
        public void ShowDate_ShouldReturnFormattedDate()
        {
            // Arrange
            var dt = new DateTime(2024, 12, 25);

            // Act
            var result = DateTimeUtility.ShowDate(dt);

            // Assert
            Assert.AreEqual("2024-12-25", result);
        }

        [TestMethod]
        public void ShowDate_ShouldReturnEmpty_WhenNull()
        {
            // Act
            var result = DateTimeUtility.ShowDate(null);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TimeAgo_ShouldReturnKoreanFormat()
        {
            // Arrange
            var dt = DateTime.Now.AddMinutes(-10);

            // Act
            var result = DateTimeUtility.TimeAgo(dt, useKorean: true);

            // Assert
            Assert.IsTrue(result.Contains("분 전"));
        }

        [TestMethod]
        public void TimeAgo_ShouldReturnEnglishFormat()
        {
            // Arrange
            var dt = DateTime.Now.AddMinutes(-10);

            // Act
            var result = DateTimeUtility.TimeAgo(dt, useKorean: false);

            // Assert
            Assert.IsTrue(result.Contains("minutes ago"));
        }

        [TestMethod]
        public void TimeAgo_ShouldHandleSecondsAgo()
        {
            // Arrange
            var dt = DateTime.Now.AddSeconds(-30);

            // Act
            var korean = DateTimeUtility.TimeAgo(dt, useKorean: true);
            var english = DateTimeUtility.TimeAgo(dt, useKorean: false);

            // Assert
            Assert.AreEqual("방금 전", korean);
            Assert.AreEqual("just now", english);
        }
    }
}
