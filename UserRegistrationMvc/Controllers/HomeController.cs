using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using UserRegistrationMvc.DataContext;
using UserRegistrationMvc.Models;
using UserRegistrationMvc.ViewModels;

namespace UserRegistrationMvc.Controllers
{
    public class HomeController : Controller
    {
        private const string LOGIN_SESSION_KEY = "login";
        private readonly Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(LOGIN_SESSION_KEY)))
            {
                return View();
            }
            return RedirectToAction("Login", "Auth");
        }

        [ChatFilter]
        public async  Task<IActionResult> Chat()
        {
            var loginedUser = HttpContext.Session.GetString(LOGIN_SESSION_KEY);
            var user = JsonConvert.DeserializeObject<UserLoginVM>(loginedUser);
            var users = await _context.Users.Where(x => x.Username != user.Username).ToListAsync();
            return View(users);
        }

        public IActionResult Privacy()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(LOGIN_SESSION_KEY)))
            {
                return View();
            }
            return RedirectToAction("Login", "Auth");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}