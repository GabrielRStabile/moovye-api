using Movye.Domain.Interfaces.DTOs;

namespace Movye.Domain.Interfaces.Services.IJwtService.Responses
{
    public class JwtServiceGenerateJwtTokenResponse : IResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }

        public JwtServiceGenerateJwtTokenResponse(string accessToken, string refreshToken)
        {
            Success = true;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }

        public JwtServiceGenerateJwtTokenResponse(List<string> errors)
        {
            Success = false;
            Errors = errors;
        }
    }
}
