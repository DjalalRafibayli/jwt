using DataAccessLayer.Abstract.Users;
using DataAccessLayer.Concrete;
using EfCodeFirst.Models.ViewModels;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Users
{
    public class UserRepo : IUserDal
    {
        public bool CheckUserExist(string username, string password)
        {
            using (var context = new Context())
            {
                return context.Users.Any(x => x.username == username && x.password == password);
            }
        }

        public bool CheckUsername(string username)
        {
            using (var context = new Context())
            {
                return context.Users.Any(x => x.username == username);
            }
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsers()
        {
            using (var context = new Context())
            {
                return context.Users.Where(x => x.active == 2).Select(x=> new UserViewModel { Id =  x.id , username = x.username, active =  x.active }).ToList();
            }

        }

        public User GetSavedRefreshTokens(string username, string refreshToken)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(x => x.username == username && x.refreshtoken == refreshToken && x.active == 2);
            }
        }

        public void UpdateUserRefreshToken(string username, string refreshToken)
        {
            using (var context = new Context())
            {
                var user = context.Users.FirstOrDefault(x => x.username == username);
                user.refreshtoken = refreshToken;
                user.refreshtokenExpireTime = DateTime.Now.AddMinutes(30);
                context.Users.Update(user);
                
                context.SaveChanges();
            }
        }
    }
}
