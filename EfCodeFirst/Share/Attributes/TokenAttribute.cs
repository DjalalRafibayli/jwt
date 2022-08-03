using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
namespace EfCodeFirst.Share.Attributes
{
    public class TokenAttribute : ActionFilterAttribute
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenAttribute(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        //public void CheckValidCookie()
        //{
        //    var accessToken = _httpContextAccessor.HttpContext.Request.Cookies["accessToken"];
        //    var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refreshToken"];

        //    if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken) )
        //    {
        //    }
        //    return 
        //}
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var refreshToken = _httpContextAccessor.HttpContext.Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
                context.Result = new RedirectToActionResult("Logout","Login",null);
        }
    }
}
