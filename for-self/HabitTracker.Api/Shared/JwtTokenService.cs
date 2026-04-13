using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HabitTracker.Api.Shared
{
    public class JwtTokenService
    {
        private string Key;
        private string Issuer;
        private string Audience;
        private int ExpiryMinutes;

        public JwtTokenService(IConfiguration config)
        {
            Key = config["Jwt:Key"]!;
            Issuer = config["Jwt:Issuer"]!;
            Audience = config["Jwt:Audience"]!;
            ExpiryMinutes = int.Parse(config["Jwt:ExpiryMinutes"]!);
        }

        public string GenerateToken(Guid userId, string email, string userName)
        {
            var claims = new[]
            {
                new Claim("userId",userId.ToString()),
                new Claim("email",email),
                new Claim("username",userName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(ExpiryMinutes),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
