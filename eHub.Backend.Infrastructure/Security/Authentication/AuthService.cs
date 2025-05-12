using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eHub.Backend.Domain.Contracts.Services;
using eHub.Backend.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace eHub.Backend.Infrastructure.Security.Authentication
{
    public class AuthService(IOptions<JwtSettings> jwtOptions) : IAuthService
    {

        private readonly JwtSettings _jwtSettings = jwtOptions.Value;

        public string GenerateJwtToken(UserModel model)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            AddOptionalClaims(model, claims);

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddDays(1),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        private static void AddOptionalClaims(UserModel model, List<Claim> claims)
        {
            if (!string.IsNullOrEmpty(model.FirstName))
                claims.Add(new Claim(JwtRegisteredClaimNames.GivenName, model.FirstName));

            if (!string.IsNullOrEmpty(model.LastName))
                claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, model.LastName));
        }
    }
}
