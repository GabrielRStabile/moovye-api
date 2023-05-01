using System.ComponentModel.DataAnnotations;

namespace Movye.Domain.Interfaces.DTOs.Auth.Requests
{
    public class UserSignUpRequest
    {
        public UserSignUpRequest(string userName, string email, DateTime birthDate)
        {
            UserName = userName;
            Email = email;
            BirthDate = birthDate;
        }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em um formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

    }
}
