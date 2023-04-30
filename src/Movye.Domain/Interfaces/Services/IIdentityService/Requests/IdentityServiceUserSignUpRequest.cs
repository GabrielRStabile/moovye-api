using Movye.Domain.Interfaces.DTOs.Auth.Requests;

namespace Movye.Domain.Interfaces.Services.IIdentityService.Requests
{
    public class IdentityServiceUserSignUpRequest
    {
        public IdentityServiceUserSignUpRequest(string userName, string email, DateTime dateOfBirth)
        {
            UserName = userName;
            Email = email;
            DateOfBirth = dateOfBirth;
        }

        public IdentityServiceUserSignUpRequest(UserSignUpRequest request)
        {
            UserName = request.UserName;
            Email = request.Email;
            DateOfBirth = request.BirthDate;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
