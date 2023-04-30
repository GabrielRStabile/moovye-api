using Microsoft.AspNetCore.Identity;
using Movye.Domain.Entities;
using Movye.Domain.Interfaces.Services.IIdentityService;
using Movye.Domain.Interfaces.Services.IIdentityService.Requests;
using Movye.Domain.Interfaces.Services.IIdentityService.Responses;

namespace Movye.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public IdentityService(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        async Task<IdentityServiceUserSignUpResponse> IIdentityService.SignUpUser(IdentityServiceUserSignUpRequest request)
        {
            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth.ToUniversalTime(),
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user);

            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(user, false);

            var response = new IdentityServiceUserSignUpResponse(result.Succeeded);

            if (!result.Succeeded && result.Errors.Count() > 0)
                response.AddError(result.Errors.Select(r => r.Description));

            return response;
        }

        async Task<IdentityServiceUserGenerateTokenResponse> IIdentityService.GenerateToken(IdentityServiceUserGenerateTokenRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return new IdentityServiceUserGenerateTokenResponse(new List<string> { "User not found" });

            var token = await _userManager.GenerateUserTokenAsync(
                user, "PasswordlessLoginTotpProvider", "passwordless-auth");

            return new IdentityServiceUserGenerateTokenResponse(token);
        }

        async Task<IdentityServiceUserValidateTokenResponse> IIdentityService.ValidateToken(IdentityServiceUserValidateTokenRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
                return new IdentityServiceUserValidateTokenResponse(new List<string> { "User not found" });

            var isValid = await _userManager.VerifyUserTokenAsync(user, "PasswordlessLoginTotpProvider", "passwordless-auth", request.Token);

            if (!isValid)
                return new IdentityServiceUserValidateTokenResponse(new List<string> { "Invalid token" });


            return new IdentityServiceUserValidateTokenResponse(isValid);
        }
    }
}
