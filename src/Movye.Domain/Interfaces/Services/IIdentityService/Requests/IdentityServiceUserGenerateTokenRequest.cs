using Movye.Domain.Interfaces.DTOs;
using Movye.Domain.Interfaces.DTOs.Auth.Requests;

namespace Movye.Domain.Interfaces.Services.IIdentityService.Requests
{
    public class IdentityServiceUserGenerateTokenRequest
    {
        public IdentityServiceUserGenerateTokenRequest(string email)
        {
            Email = email;
        }

        public IdentityServiceUserGenerateTokenRequest(UserSendTokenRequest request)
        {
            Email = request.Email;
        }

        public string Email { get; set; }

    }
}
