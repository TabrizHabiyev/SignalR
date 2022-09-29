using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistrationMvc.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ConnectionId { get; set; }

        [NotMapped]
        List<UserRole> UserRoles { get; set; }

    }
}
