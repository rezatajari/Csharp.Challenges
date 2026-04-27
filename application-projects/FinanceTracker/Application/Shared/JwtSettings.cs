using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Shared
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Key { get; init; } = string.Empty;
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public int DurationInMinutes { get; init; }
    }
}
