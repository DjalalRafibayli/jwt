using DataAccessLayer.Abstract.Users;
using EfCodeFirstAPI.JWT.Interface;
using EfCodeFirstAPI.JWT.Model;
using EfCodeFirstAPI.JWT.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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

            setTokenCookie(token.RefreshToken);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh(Tokens token)//,string username
        {
            try
            {
                var principal = _jWTService.GetPrincipalFromExpiredToken(token.Token);
                if (principal == null)
                {
                    return BadRequest("Invalid access token or refresh token");
                }
                var username = principal.Identity?.Name;

                //retrieve the saved refresh token from database
                var savedRefreshToken = _userDal.GetSavedRefreshTokens(username, token.RefreshToken);
                if (savedRefreshToken == null)
                {
                    return Unauthorized("Invalid attempt!");
                }
                if (savedRefreshToken.refreshtoken != token.RefreshToken || savedRefreshToken.refreshtokenExpireTime <= DateTime.Now)
                {
                    return Unauthorized("Invalid attempt!");
                }

                var newJwtToken = _jWTService.GenerateRefreshToken(username);

                if (newJwtToken == null)
                {
                    return Unauthorized("Invalid attempt!");
                }

                // saving refresh token to the db
                //UserRefreshTokens obj = new UserRefreshTokens
                //{
                //    RefreshToken = newJwtToken.Refresh_Token,
                //    UserName = username
                //};
                _userDal.UpdateUserRefreshToken(username, newJwtToken.RefreshToken);
                //userServiceRepository.DeleteUserRefreshTokens(username, token.Refresh_Token);
                //userServiceRepository.AddUserRefreshTokens(obj);
                //userServiceRepository.SaveCommit();
                return Ok(newJwtToken);
            }
            catch (Exception ex)
            {
                return Unauthorized("Invalid attempt!");
            }
        }


        //ancaq refresh token parametri gondermekle token almaq
        [HttpPost]
        [Route("refreshToken")]
        public IActionResult RefreshToken([FromForm] string refreshToken)//,string username
        {
            try
            {
                //retrieve the saved refresh token from database
                var savedRefreshToken = _userDal.GetSavedRefreshTokensWithRefresh(refreshToken);

                if (savedRefreshToken == null)
                {
                    return Unauthorized("Invalid attempt!");
                }
                if (savedRefreshToken.refreshtoken != refreshToken || savedRefreshToken.refreshtokenExpireTime <= DateTime.Now)
                {
                    return Unauthorized("Invalid attempt!");
                }

                var newJwtToken = _jWTService.GenerateRefreshToken(savedRefreshToken.username);

                if (newJwtToken == null)
                {
                    return Unauthorized("Invalid attempt!");
                }

                // saving refresh token to the db
                //UserRefreshTokens obj = new UserRefreshTokens
                //{
                //    RefreshToken = newJwtToken.Refresh_Token,
                //    UserName = username
                //};
                _userDal.UpdateUserRefreshToken(savedRefreshToken.username, newJwtToken.RefreshToken);
                //userServiceRepository.DeleteUserRefreshTokens(username, token.Refresh_Token);
                //userServiceRepository.AddUserRefreshTokens(obj);
                //userServiceRepository.SaveCommit();
                return Ok(newJwtToken);
            }
            catch (Exception ex)
            {
                return Unauthorized("Invalid attempt!");
            }
        }

        [HttpPost("CheckUsername/{username}")]
        //[HttpPost("CheckUsername")]
        public IActionResult CheckUsername([Required] string username)
        {
            var exist = _userDal.CheckUsername(username);
            return Ok(exist);
        }

        private void setTokenCookie(string token)
        {
            // append cookie with refresh token to the http response
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddHours(1)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
