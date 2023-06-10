using Microsoft.AspNetCore.Identity;

namespace Movye.Domain.Entities
{
    public class User : IdentityUser
    {
        public DateTime DateOfBirth { get; set; }
    }
}
