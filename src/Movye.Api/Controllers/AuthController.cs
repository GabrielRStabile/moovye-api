using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Movye.Api.Controllers.Shared;
using Movye.Domain.Entities;
using Movye.Domain.Interfaces.DTOs;
using Movye.Domain.Interfaces.DTOs.Auth.Requests;
using Movye.Domain.Interfaces.DTOs.Auth.Responses;
using Movye.Domain.Interfaces.Services.IIdentityService;
using Movye.Domain.Interfaces.Services.IIdentityService.Requests;
using Movye.Domain.Interfaces.Services.IIdentityService.Responses;
using Movye.Domain.Interfaces.Services.IJwtService;
using Movye.Domain.Interfaces.Services.IMailService;
using Movye.Domain.Interfaces.Services.IMailService.Requests;

namespace Movye.Api.Controllers
{
    public class AuthController : ApiControllerBase
    {
        private IIdentityService _identityService;
        private IJwtService _jwtService;
        private UserManager<User> _userManager;
        private IMailService _mailService;


        [ActivatorUtilitiesConstructor]
        public AuthController(IIdentityService identityService, IJwtService jwtService, UserManager<User> userManager, IMailService mailService)
        {
            _identityService = identityService;
            _jwtService = jwtService;
            _userManager = userManager;
            _mailService = mailService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] UserSignUpRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            IdentityServiceUserSignUpResponse response = await _identityService.SignUpUser(new IdentityServiceUserSignUpRequest(request));

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("token")]
        public async Task<ActionResult<UserSendTokenResponse>> GenerateToken(UserSendTokenRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _identityService.GenerateToken(new IdentityServiceUserGenerateTokenRequest(request));

            if (!response.Success)
                return BadRequest(response);

            await _mailService.SendEmail(
                new MailServiceSendEmailRequest(
                    request.Email, "Acesso ao Movye App", $"Seu token de acesso é: {response.Token}", MailSender.AuthenticationService
                )
            );

            return Ok(response);
        }

        [HttpPost("signin")]
        public async Task<ActionResult<UserLoginWithTokenResponse>> ValidateToken([FromBody] UserLoginWithTokenRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var response = await _identityService.ValidateToken(new IdentityServiceUserValidateTokenRequest(request));

            if (!response.Success)
                return BadRequest(response);

            var user = await _userManager.FindByEmailAsync(request.Email);

            var token = await _jwtService.GenerateJwtToken(user!);

            return Ok(token);
        }
    }
}
