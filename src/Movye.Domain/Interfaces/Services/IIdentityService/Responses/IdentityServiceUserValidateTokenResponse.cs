using Movye.Domain.Interfaces.DTOs;

namespace Movye.Domain.Interfaces.Services.IIdentityService.Responses
{
    public class IdentityServiceUserValidateTokenResponse : IResponse
    {
        public IdentityServiceUserValidateTokenResponse(bool success)
        {
            Success = success;
        }

        public IdentityServiceUserValidateTokenResponse(List<string> errors)
        {
            Success = false;
            Errors = errors;
        }
    }
}
