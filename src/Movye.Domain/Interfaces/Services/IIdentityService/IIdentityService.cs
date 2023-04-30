using Movye.Domain.Interfaces.Services.IIdentityService.Requests;
using Movye.Domain.Interfaces.Services.IIdentityService.Responses;

namespace Movye.Domain.Interfaces.Services.IIdentityService
{
    public interface IIdentityService
    {
        Task<IdentityServiceUserSignUpResponse> SignUpUser(IdentityServiceUserSignUpRequest request);
        Task<IdentityServiceUserValidateTokenResponse> ValidateToken(IdentityServiceUserValidateTokenRequest request);
        Task<IdentityServiceUserGenerateTokenResponse> GenerateToken(IdentityServiceUserGenerateTokenRequest request);
    }
}
