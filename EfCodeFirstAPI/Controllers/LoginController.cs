using EfCodeFirstAPI.JWT.Interface;
using EfCodeFirstAPI.JWT.Model;
using EfCodeFirstAPI.JWT.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EfCodeFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IJwtSerivce _jWTService;

        public LoginController(IJwtSerivce jWTService)
        {
            _jWTService = jWTService;
        }

        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(JWTUsers usersdata)
        {
            JWTUsers user = new JWTUsers
            {
                username = usersdata.username,
                password = usersdata.password,
            };
            var token = _jWTService.Authenticate(user);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
