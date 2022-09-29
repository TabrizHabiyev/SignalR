using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace UserRegistrationMvc.ViewModels
{
    public class UserLoginVM
    {
        public string Username { get; set; } = null!;

        [DataType(DataType.Password),JsonIgnore]
        public string Password { get; set; } = null!;

        public List<string> Roles { get; set; } = new List<string>();
    }
}
