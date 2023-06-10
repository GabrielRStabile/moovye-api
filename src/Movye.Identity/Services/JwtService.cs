using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Movye.Domain.Entities;
using Movye.Domain.Interfaces.Services.IJwtService;
using Movye.Domain.Interfaces.Services.IJwtService.Responses;
using Movye.Identity.Configurations;

namespace Movye.Identity.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly UserManager<User> _userManager;

        public JwtService(IOptions<JwtOptions> jwtOptions, UserManager<User> userManager)
        {
            _jwtOptions = jwtOptions.Value;
            _userManager = userManager;
        }

        async public Task<JwtServiceGenerateJwtTokenResponse> GenerateJwtToken(User user)
        {
            var tokenClaims = await GetClaims(user);

            var accessTokenExpiration = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddSeconds(
                _jwtOptions.RefreshTokenExpiration
            );

            var accessToken = GenerateToken(tokenClaims, accessTokenExpiration);
            var refreshToken = GenerateToken(tokenClaims, refreshTokenExpiration);

            return new JwtServiceGenerateJwtTokenResponse(accessToken, refreshToken);
        }

        async public Task<IList<Claim>> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())
            };

            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(userClaims);

            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            return claims;
        }

        private string GenerateToken(IEnumerable<Claim> claims, DateTime expiration)
        {
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: expiration,
                signingCredentials: _jwtOptions.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
