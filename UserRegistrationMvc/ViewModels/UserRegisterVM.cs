using System.ComponentModel.DataAnnotations;

namespace UserRegistrationMvc.ViewModels
{
    public class UserRegisterVM
    {
        public string Username { get; set; } = null!;
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
