using UserRegistrationMvc.Models;
using UserRegistrationMvc.ViewModels;

namespace UserRegistrationMvc.Services
{
    public interface IAuthService
    {
        Task<string> Register(UserRegisterVM registerVM);
        Task<UserLoginVM> Login(UserLoginVM loginVM);
        Task<List<User>> GetUsers();
    }
}
