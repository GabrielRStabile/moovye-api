using System.Security.Claims;
using Movye.Domain.Entities;
using Movye.Domain.Interfaces.Services.IJwtService.Responses;

namespace Movye.Domain.Interfaces.Services.IJwtService
{
    public interface IJwtService
    {
        Task<JwtServiceGenerateJwtTokenResponse> GenerateJwtToken(User user);
        Task<IList<Claim>> GetClaims(User user);
        string GetUserIdFromToken(string token);
    }
}
