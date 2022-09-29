// create actionfilter for role 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using UserRegistrationMvc.Enums;
using UserRegistrationMvc.ViewModels;

public class RoleFilter: ActionFilterAttribute
{
     public RolesEnum Role { get; set; }
     public RoleFilter(RolesEnum role)
     {
        Role = role;
     }

     public override void OnActionExecuting(ActionExecutingContext context)
     {
            if(context.HttpContext.Session.GetString("login") != null)
            {
                 var userDatas = JsonConvert.DeserializeObject<UserLoginVM>(context.HttpContext.Session.GetString("login"));
                    if(userDatas.Roles.Contains(Role.ToString()))
                    {
                        base.OnActionExecuting(context);
                    }
                    else
                    {
                        context.Result = new RedirectResult("/Auth/Login");
                    }
            }
            else
            {
                context.Result = new RedirectResult("/Auth/Login");
            }
     }
}