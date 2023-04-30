using Movye.Domain.Interfaces.DTOs.Auth.Requests;

namespace Movye.Domain.Interfaces.Services.IIdentityService.Requests
{
    public class IdentityServiceUserValidateTokenRequest
    {
        public IdentityServiceUserValidateTokenRequest(string token, string email)
        {
            Token = token;
            Email = email;
        }

        public IdentityServiceUserValidateTokenRequest(UserLoginWithTokenRequest request)
        {
            Token = request.Token;
            Email = request.Email;
        }

        public string Token { get; set; }
        public string Email { get; set; }
    }
}
