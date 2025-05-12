using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eHub.Backend.Domain.Contracts.Services;
using eHub.Backend.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace eHub.Backend.Infrastructure.Security.Authentication
{
    public class AuthService(JwtSettings jwtSettings) : IAuthService
    {

        private readonly JwtSettings _jwtSettings = jwtSettings;

        public string GenerateJwtToken(UserModel model)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, model.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, model.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())   // ¿PARA QUÉ LO NECESITO? ¿QUÉ ES LO DE JTI?
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddDays(1),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
