using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Shared
{
    public class JwtSettings
    {
        public string Key { get; init; } = default!;
        public string Issuer { get; init; } = default!;
        public string Audience { get; init; } = default!;
        public int DurationInMinutes { get; init; }
    }
}
