using Application.Interfaces;
using Application.Shared;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication
{
    public class JwtProvider(IOptions<JwtSettings> settings) : IJwtProvider
    {
        private readonly JwtSettings _settings = settings.Value;

        public string Generate(User user)
        {
            var claims = new Claim[]
            {
                new (JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new (JwtRegisteredClaimNames.Email,user.Email.ToString()),
                new ("Username",user.Username)
            };

            var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token =
                new JwtSecurityToken(_settings.Issuer, _settings.Audience, claims,
                    null, DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes), creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
