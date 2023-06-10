using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Movye.Domain.Interfaces.DTOs
{
    public class UserSendTokenRequest
    {
        public UserSendTokenRequest(string email)
        {
            Email = email;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em um formato inválido")]
        [FromQuery(Name = "email")]
        public string Email { get; set; }
    }
}
