using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCodeFirst.Share.Logout
{
    public class RediretToLogout : IRediretToLogout, IActionFilter
    {
        public void LocalRedirect(ActionExecutingContext context)
        {
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = new RedirectToActionResult("Logout", "Login", null);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
