using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UserRegistrationMvc.DataContext;
using UserRegistrationMvc.Models;
using UserRegistrationMvc.ViewModels;

namespace SignalRTask
{
    public class ChatHub : Hub
    {
        private readonly Context _context;
        private readonly HttpContextAccessor _httpContextAccessor;
        public ChatHub(Context context , HttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SendMessageUser(string id, string message, string typing)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == int.Parse(id));

            await Clients.Client(user.ConnectionId).SendAsync("ChatUserToUser", user.Id, message);
        }

        public async Task UserKeyup(string id, string typing)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(x => x.Id == int.Parse(id));
            await Clients.Client(user.ConnectionId).SendAsync("UserTyping", user.Id, typing);
        }

        public override Task OnConnectedAsync()
        {
            
            var loginedUser = _httpContextAccessor.HttpContext.Session.GetString("login");

            var user = JsonConvert.DeserializeObject<UserLoginVM>(loginedUser);

            User? userDb = _context.Users.FirstOrDefault(x => x.Username == user.Username);

            userDb.ConnectionId = Context.ConnectionId;

            _context.SaveChanges();
            
            Clients.All.SendAsync("Connected", userDb.Id);
            return base.OnConnectedAsync();
        }
    } 
}