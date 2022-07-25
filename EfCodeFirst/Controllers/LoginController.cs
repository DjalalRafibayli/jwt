using EfCodeFirst.Models.ViewModels;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using EfCodeFirstAPI.JWT.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EfCodeFirst.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHelperLogin _helperLogin;
        private readonly IHelperGet _helperGet;
        public IConfiguration Configuration { get; }


        public LoginController(IHelperLogin helperLogin, IConfiguration configuration, IHelperGet helperGet)
        {
            _helperLogin = helperLogin;
            Configuration = configuration;
            _helperGet = helperGet;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel p)
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity identity = null;
                bool isAuthenticated = false;

                JWTUsers login = new JWTUsers()
                {
                    username = p.Username,
                    password = p.Password
                };

                string jwtToken = await _helperLogin.LoginRepoAsync(Configuration["Api:baseUrl"] + "Login/authenticate", login);
                if (string.IsNullOrEmpty(jwtToken))
                {
                    isAuthenticated = false;
                }
                else
                {
                    identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,p.Username),
                        new Claim(ClaimTypes.Role,"Admin")
                    }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticated = true;
                }

                if (isAuthenticated)
                {
                    var principal = new ClaimsPrincipal(identity);

                    var Login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    p.Message = "Istifadeci adi veya parol sehvdir";
                }
            }
            else
            {
                p.Message = "Sehv var!";
            }
            return View();
        }

        public async Task<JsonResult> CheckUsername(LoginViewModel p)
        {
            string j = await _helperGet.GetRepoBool(Configuration["Api:baseUrl"] + "Login/CheckUsername", p.Username);
            
            bool exist = false;
            if (j == "true")
            {
                exist = true;
            }
            else
            {
                exist = false;
            }
            return Json(exist);
        }
        //public IActionResult Logout()
        //{
        //    var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        //    return RedirectToAction("Login");
        //}
    }
}
