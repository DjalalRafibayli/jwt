using EfCodeFirst.Config.Encyript;
using EfCodeFirst.Models.ApiResponse;
using EfCodeFirst.Models.ViewModels;
using EfCodeFirst.Share.Api.Interfaces.Helpers;
using EfCodeFirstAPI.JWT.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EfCodeFirst.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHelperLogin _helperLogin;
        private readonly IHelperGet _helperGet;
        private readonly IEncyript _encyript;
        public IConfiguration Configuration { get; }


        public LoginController(IHelperLogin helperLogin, IConfiguration configuration, IHelperGet helperGet, IEncyript encyript)
        {
            _helperLogin = helperLogin;
            Configuration = configuration;
            _helperGet = helperGet;
            _encyript = encyript;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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

                //string jwtToken = await _helperLogin.LoginRepoAsync(Configuration["Api:baseUrl"] + "Login/authenticate", login);
                ResponseTokens Tokens= await _helperLogin.LoginRepoAsync(Configuration["Api:baseUrl"] + "Login/authenticate", login);
                string jwtToken = Tokens.Token;
                string refreshToken = Tokens.refreshToken;
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

                    //var jwtJson = JObject.Parse(jwtToken);

                    //string accessToken = jwtJson.SelectToken("token").Value<string>();
                    CookieOptions cookieOptionsToken = new CookieOptions();
                    cookieOptionsToken.Expires = DateTime.Now.AddMinutes(30);
                    

                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddHours(0.5);
                    
                    var encyriptToken =  _encyript.Encrypt(jwtToken, Configuration["Keys:JwtEnckey"]);
                    var encyriptrefreshToken =  _encyript.Encrypt(refreshToken, Configuration["Keys:JwtEnckey"]);
                    
                    Response.Cookies.Append("accessToken", encyriptToken, cookieOptionsToken);
                    Response.Cookies.Append("refreshToken", encyriptrefreshToken, cookieOptions);
                    isAuthenticated = true;
                }

                if (isAuthenticated)
                {
                    var principal = new ClaimsPrincipal(identity);

                    var Login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    p.Message = "enter";
                    //return RedirectToAction("Index", "Home");
                    return Json(p);
                }
                else
                {
                    p.Message = "Istifadeci adi veya parol sehvdir";
                }
                return Json(p);
            }
            else
            {
                p.Message = "Sehv var!";
            }
            return Json(p);
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
