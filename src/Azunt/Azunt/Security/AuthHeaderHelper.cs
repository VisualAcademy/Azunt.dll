using System;

namespace Azunt.Security
{
    public static class AuthHeaderHelper
    {
        public static string NormalizeBearerToken(string? authenticationHeader)
        {
            if (string.IsNullOrWhiteSpace(authenticationHeader))
                return string.Empty;

            var token = authenticationHeader.Trim();

            if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                token = token.Substring("Bearer ".Length).Trim();

            return token;
        }
    }
}
