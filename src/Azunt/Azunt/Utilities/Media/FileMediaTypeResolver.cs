using System;
using System.Collections.Generic;
using System.IO;

namespace Azunt.Utilities.Media
{
    /// <summary>
    /// 파일 이름 또는 확장자에서 HTTP Media Type(MIME type)을 해석합니다.
    /// 웹/스토리지/메시징 등 프로토콜에 구애받지 않고 사용할 수 있는 경량 리졸버입니다.
    /// </summary>
    public static class FileMediaTypeResolver
    {
        /// <summary>
        /// 표준 기본 Media Type
        /// </summary>
        public const string DefaultMediaType = "application/octet-stream";

        // 자주 쓰는 확장자만 엄선하여 매핑 (요구 시 확장 가능)
        private static readonly IReadOnlyDictionary<string, string> Map =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // 문서
                [".pdf"] = "application/pdf",
                [".doc"] = "application/msword",
                [".docx"] = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                [".xls"] = "application/vnd.ms-excel",
                [".xlsx"] = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                [".ppt"] = "application/vnd.ms-powerpoint",
                [".pptx"] = "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                [".txt"] = "text/plain",

                // 이미지
                [".jpg"] = "image/jpeg",
                [".jpeg"] = "image/jpeg",
                [".png"] = "image/png",
                [".gif"] = "image/gif",
            };

        /// <summary>
        /// 파일 이름 또는 확장자에서 Media Type을 반환합니다.
        /// 매핑에 없으면 <paramref name="defaultType"/> (기본: <see cref="DefaultMediaType"/>)을 반환합니다.
        /// </summary>
        /// <param name="fileNameOrExtension">파일명("a.pdf") 또는 확장자(".pdf" 또는 "pdf")</param>
        /// <param name="defaultType">매핑 실패 시 반환할 기본 Media Type</param>
        public static string GetMediaType(string fileNameOrExtension, string defaultType = DefaultMediaType)
            => TryGetMediaType(fileNameOrExtension, out var mediaType) ? mediaType : defaultType;

        /// <summary>
        /// 파일 이름 또는 확장자에서 Media Type 해석을 시도합니다.
        /// 성공 시 true와 <paramref name="mediaType"/>를 반환합니다.
        /// </summary>
        /// <param name="fileNameOrExtension">파일명("a.pdf") 또는 확장자(".pdf" 또는 "pdf")</param>
        /// <param name="mediaType">해석된 Media Type</param>
        public static bool TryGetMediaType(string fileNameOrExtension, out string mediaType)
        {
            mediaType = null!;
            var ext = NormalizeExtension(fileNameOrExtension);
            if (string.IsNullOrEmpty(ext)) return false;
            return Map.TryGetValue(ext, out mediaType);
        }

        /// <summary>
        /// 입력을 ".ext" 형태의 확장자로 정규화합니다.
        /// 파일명이면 확장자를 추출하고, "pdf"처럼 점이 없는 경우에도 ".pdf"로 변환합니다.
        /// </summary>
        private static string NormalizeExtension(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            // "pdf" → ".pdf"
            if (input.IndexOf('.') < 0)
            {
                return "." + input.Trim().ToLowerInvariant();
            }

            // 파일명 또는 ".ext" ⇒ 확장자 추출
            var ext = input[0] == '.' && input.LastIndexOf('.') == 0
                ? input
                : Path.GetExtension(input);

            return string.IsNullOrEmpty(ext) ? string.Empty : ext.ToLowerInvariant();
        }
    }
}
