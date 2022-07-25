using DataAccessLayer.Abstract.Users;
using EfCodeFirstAPI.JWT.Interface;
using EfCodeFirstAPI.JWT.Model;
using EfCodeFirstAPI.JWT.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EfCodeFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IJwtSerivce _jWTService;
        private readonly IUserDal _userDal;

        public LoginController(IJwtSerivce jWTService, IUserDal userDal)
        {
            _jWTService = jWTService;
            _userDal = userDal;
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

        [HttpPost("CheckUsername/{username}")]
        //[HttpPost("CheckUsername")]
        public IActionResult CheckUsername([Required]string username)
        {
            var exist = _userDal.CheckUsername(username);
            return Ok(exist);
        }
    }
}
