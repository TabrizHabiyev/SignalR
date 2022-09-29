using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserRegistrationMvc.DataContext;
using UserRegistrationMvc.Services;
using UserRegistrationMvc.ViewModels;

namespace UserRegistrationMvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly Context _context;
        private const string LOGIN_SESSION_KEY = "login";
        public AuthController(IAuthService authService, Context context)
        {
            _authService = authService;
            _context = context;
        }

        public IActionResult Register()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(LOGIN_SESSION_KEY)))
                return RedirectToAction("Login");
            return View();
        }
        public async Task<IActionResult> Index()
        {
            return View(await _authService.GetUsers());
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM registerVM)
        {
            var result = await _authService.Register(registerVM);
            if (result != "success")
            {
                ModelState.AddModelError("", result);
                return View(registerVM);
            }
            return RedirectToAction(nameof(Register));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM loginVM)
        {
            var result = await _authService.Login(loginVM);
           
            if (result == null)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View(loginVM);
            }
            HttpContext.Session.SetString(LOGIN_SESSION_KEY, JsonConvert.SerializeObject(result));
            return RedirectToAction("Index");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove(LOGIN_SESSION_KEY);
            return RedirectToAction(nameof(Login));
        }

        public IActionResult ShowMe()
        {
            var user = HttpContext.Session.GetString(LOGIN_SESSION_KEY);
            return Json(JsonConvert.DeserializeObject<UserLoginVM>(user));
        }
    }
}
