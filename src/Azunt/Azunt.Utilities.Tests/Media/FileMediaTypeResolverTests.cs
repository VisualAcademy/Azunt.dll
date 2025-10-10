using Azunt.Utilities.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azunt.Utilities.Tests.Media
{
    [TestClass]
    public class FileMediaTypeResolverTests
    {
        [TestMethod]
        [DataRow(".pdf", "application/pdf")]
        [DataRow(".doc", "application/msword")]
        [DataRow(".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
        [DataRow(".xls", "application/vnd.ms-excel")]
        [DataRow(".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        [DataRow(".ppt", "application/vnd.ms-powerpoint")]
        [DataRow(".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation")]
        [DataRow(".txt", "text/plain")]
        public void KnownDocumentExtensions_Should_MapToExpectedMediaType(string ext, string expected)
        {
            var ok = FileMediaTypeResolver.TryGetMediaType(ext, out var mediaType);

            Assert.IsTrue(ok, "TryGetMediaType should succeed for known extensions.");
            Assert.AreEqual(expected, mediaType);
        }

        [TestMethod]
        [DataRow(".jpg", "image/jpeg")]
        [DataRow(".jpeg", "image/jpeg")]
        [DataRow(".png", "image/png")]
        [DataRow(".gif", "image/gif")]
        public void KnownImageExtensions_Should_MapToExpectedMediaType(string ext, string expected)
        {
            var ok = FileMediaTypeResolver.TryGetMediaType(ext, out var mediaType);

            Assert.IsTrue(ok);
            Assert.AreEqual(expected, mediaType);
        }

        [TestMethod]
        [DataRow("report.PDF", "application/pdf")]
        [DataRow("resume.Docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document")]
        [DataRow("sheet.XLSX", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")]
        [DataRow("presentation.ppt", "application/vnd.ms-powerpoint")]
        [DataRow("image.JpEg", "image/jpeg")]
        [DataRow("note.txt", "text/plain")]
        public void FileNameInputs_Should_WorkAndBeCaseInsensitive(string fileName, string expected)
        {
            var mediaType = FileMediaTypeResolver.GetMediaType(fileName);

            Assert.AreEqual(expected, mediaType);
        }

        [TestMethod]
        [DataRow("pdf", "application/pdf")]
        [DataRow("DOC", "application/msword")]
        [DataRow("Png", "image/png")]
        [DataRow("gif", "image/gif")]
        public void ExtensionWithoutDot_Should_BeNormalized(string input, string expected)
        {
            var ok = FileMediaTypeResolver.TryGetMediaType(input, out var mediaType);

            Assert.IsTrue(ok);
            Assert.AreEqual(expected, mediaType);
        }

        [TestMethod]
        public void UnknownExtension_TryGet_Should_ReturnFalse()
        {
            var ok = FileMediaTypeResolver.TryGetMediaType(".unknownext", out var mediaType);

            Assert.IsFalse(ok);
            Assert.IsNull(mediaType);
        }

        [TestMethod]
        public void UnknownExtension_GetMediaType_Should_ReturnDefault()
        {
            var mediaType = FileMediaTypeResolver.GetMediaType(".unknownext");

            Assert.AreEqual(FileMediaTypeResolver.DefaultMediaType, mediaType);
        }

        [TestMethod]
        public void UnknownExtension_GetMediaType_WithCustomDefault_Should_ReturnCustomDefault()
        {
            var customDefault = "application/x-custom";
            var mediaType = FileMediaTypeResolver.GetMediaType(".unknownext", customDefault);

            Assert.AreEqual(customDefault, mediaType);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        public void EmptyOrNullInput_TryGet_Should_ReturnFalse(string input)
        {
            var ok = FileMediaTypeResolver.TryGetMediaType(input, out var mediaType);

            Assert.IsFalse(ok);
            Assert.IsNull(mediaType);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("   ")]
        [DataRow(null)]
        public void EmptyOrNullInput_GetMediaType_Should_ReturnDefault(string input)
        {
            var mediaType = FileMediaTypeResolver.GetMediaType(input);

            Assert.AreEqual(FileMediaTypeResolver.DefaultMediaType, mediaType);
        }
    }
}
