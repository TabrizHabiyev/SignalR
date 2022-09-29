// create actionfilter for role 

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using UserRegistrationMvc.DataContext;
using UserRegistrationMvc.Enums;
using UserRegistrationMvc.ViewModels;

public class ChatFilter : ActionFilterAttribute
{

    public override void OnActionExecuting(ActionExecutingContext context)
    {

        if (string.IsNullOrWhiteSpace(context.HttpContext.Session.GetString("login")))
        {
            context.Result = new RedirectResult("/Auth/Login");
        }
        else
        {
            base.OnActionExecuting(context);
        }
    }
}