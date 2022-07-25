using DataAccessLayer.Abstract.Users;
using EfCodeFirstAPI.JWT.Interface;
using EfCodeFirstAPI.JWT.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EfCodeFirstAPI.JWT.Repository
{
    public class JWTRepository : IJwtSerivce
    {
        private readonly IConfiguration _configuration;
        private readonly IUserDal _userDal;

        public JWTRepository(IConfiguration configuration, IUserDal userDal)
        {
            _configuration = configuration;
            _userDal = userDal;
        }

        public Tokens Authenticate(JWTUsers jWTUsers)
        {
            if (!_userDal.CheckUserExist(jWTUsers.username, jWTUsers.password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
             new Claim(ClaimTypes.Name, jWTUsers.username)
               }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
    }
}
