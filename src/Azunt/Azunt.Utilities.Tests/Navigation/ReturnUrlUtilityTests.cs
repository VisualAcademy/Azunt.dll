using System;
using Azunt.Utilities.Navigation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azunt.Utilities.Tests.Navigation
{
    [TestClass]
    public class ReturnUrlUtilityTests
    {
        [TestMethod]
        public void Normalize_ShouldReturnDefault_WhenReturnUrlIsNullOrWhitespace()
        {
            Assert.AreEqual("/", ReturnUrlUtility.Normalize(null));
            Assert.AreEqual("/", ReturnUrlUtility.Normalize(""));
            Assert.AreEqual("/", ReturnUrlUtility.Normalize("   "));
        }

        [TestMethod]
        public void Normalize_ShouldReturnNormalizedDefault_WhenDefaultPathIsInvalid()
        {
            Assert.AreEqual("/", ReturnUrlUtility.Normalize(null, ""));
            Assert.AreEqual("/", ReturnUrlUtility.Normalize(null, "   "));
            Assert.AreEqual("/home", ReturnUrlUtility.Normalize(null, "home"));
            Assert.AreEqual("/home", ReturnUrlUtility.Normalize(null, "/home"));
            Assert.AreEqual("/home", ReturnUrlUtility.Normalize(null, "~/home"));
        }

        [TestMethod]
        public void Normalize_ShouldEnsureRootRelative()
        {
            Assert.AreEqual("/dashboard", ReturnUrlUtility.Normalize("dashboard"));
            Assert.AreEqual("/dashboard", ReturnUrlUtility.Normalize("/dashboard"));
            Assert.AreEqual("/dashboard", ReturnUrlUtility.Normalize("~/dashboard"));
            Assert.AreEqual("/dashboard", ReturnUrlUtility.Normalize(" ~/dashboard "));
        }

        [TestMethod]
        public void Normalize_ShouldConvertBackslashesToSlashes()
        {
            Assert.AreEqual("/a/b", ReturnUrlUtility.Normalize(@"\a\b"));
            Assert.AreEqual("/a/b", ReturnUrlUtility.Normalize(@"a\b"));
            Assert.AreEqual("/a/b", ReturnUrlUtility.Normalize(@"~\a\b"));
            Assert.AreEqual("/a/b", ReturnUrlUtility.Normalize(@"~/a\b"));
        }

        [TestMethod]
        public void Normalize_ShouldBlockAbsoluteUrls()
        {
            Assert.AreEqual("/", ReturnUrlUtility.Normalize("https://azunt.com"));
            Assert.AreEqual("/", ReturnUrlUtility.Normalize("http://azunt.com/path"));
            Assert.AreEqual("/", ReturnUrlUtility.Normalize("https://example.com/anywhere", "/"));
            Assert.AreEqual("/fallback", ReturnUrlUtility.Normalize("https://example.com", "/fallback"));
        }

        [TestMethod]
        public void Normalize_ShouldBlockSchemeRelativeUrls()
        {
            Assert.AreEqual("/", ReturnUrlUtility.Normalize("//azunt.com"));
            Assert.AreEqual("/fallback", ReturnUrlUtility.Normalize("//azunt.com/path", "/fallback"));
        }

        [TestMethod]
        public void Normalize_WithBaseUri_ShouldReturnDefault_WhenHostOrPortDiffers()
        {
            var baseUri = new Uri("https://azunt.com/");

            // absolute is already blocked by Normalize(returnUrl)
            Assert.AreEqual("/", ReturnUrlUtility.Normalize("https://example.com", baseUri));

            // scheme-relative is blocked by Normalize(returnUrl)
            Assert.AreEqual("/", ReturnUrlUtility.Normalize("//example.com/path", baseUri));

            // ensure host differs (should fall back)
            var differentHostBaseUri = new Uri("https://login.azunt.com/");
            Assert.AreEqual("/", ReturnUrlUtility.Normalize("/dashboard", differentHostBaseUri, "/"));

            // port differs (should fall back)
            var baseUriWithPort = new Uri("https://azunt.com:8443/");
            Assert.AreEqual("/", ReturnUrlUtility.Normalize("/dashboard", baseUriWithPort, "/"));
        }

        [TestMethod]
        public void Normalize_WithBaseUri_ShouldReturnNormalized_WhenSameHostAndPort()
        {
            var baseUri = new Uri("https://azunt.com/app/");

            Assert.AreEqual("/dashboard", ReturnUrlUtility.Normalize("dashboard", baseUri));
            Assert.AreEqual("/dashboard", ReturnUrlUtility.Normalize("~/dashboard", baseUri));
            Assert.AreEqual("/dashboard?x=1", ReturnUrlUtility.Normalize("/dashboard?x=1", baseUri));
        }

        [TestMethod]
        public void Normalize_ShouldHandleTildeOnly_AsInvalidAndFallbackToDefaultPath()
        {
            // "~" alone is considered invalid input -> fallback
            Assert.AreEqual("/", ReturnUrlUtility.Normalize("~"));
            Assert.AreEqual("/", ReturnUrlUtility.Normalize("~", "/"));
            Assert.AreEqual("/fallback", ReturnUrlUtility.Normalize("~", "/fallback"));
        }
    }
}
