using System.ComponentModel.DataAnnotations;

namespace Movye.Domain.Interfaces.DTOs.Auth.Requests
{
    public class UserLoginWithTokenRequest
    {
        public UserLoginWithTokenRequest(string email, string token)
        {
            Email = email;
            Token = token;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em um formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Token { get; set; }
    }
}
