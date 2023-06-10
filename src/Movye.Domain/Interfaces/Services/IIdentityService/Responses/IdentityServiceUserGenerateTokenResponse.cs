
using Movye.Domain.Interfaces.DTOs;

namespace Movye.Domain.Interfaces.Services.IIdentityService.Responses
{
    public class IdentityServiceUserGenerateTokenResponse : IResponse
    {
        public string? Token { get; set; }

        public IdentityServiceUserGenerateTokenResponse(String token)
        {
            Success = true;
            Token = token;
        }

        public IdentityServiceUserGenerateTokenResponse(List<string> errors)
        {
            Success = false;
            Errors = errors;
        }
    }
}
