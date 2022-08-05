using AnotherModel.FilterModels.User;
using DataAccessLayer.Abstract.Users;
using DataAccessLayer.Concrete;
using DataAccessLayer.Models.Page;
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

        public async Task<PagedResult<UserViewModel>> GetAllUsers(int page, int limit, UserFM userFM)
        {
            using (var context = new Context())
            {
                //return context.Users.Where(x => x.active == 2).Select(x => new UserViewModel { Id = x.id, username = x.username, active = x.active }).ToList();              
                UserViewModel userViewModel = new UserViewModel();
                IQueryable<User> queryList = context.Users.Where(x => x.active == 2);
                //queryList = context.Users.Where(x => x.active == 2 && x.username.Contains(userFM.username));
                if (!string.IsNullOrEmpty(userFM.username))
                    queryList = queryList.Where(x=> x.username.Contains(userFM.username));
                var query = queryList.Select(x =>
                      new UserViewModel
                      {
                          Id = x.id,
                          active = x.active,
                          username = x.username,
                      }
                      ).Skip((page - 1) * limit).Take(limit).ToList();


                //var query = context.Users.Where(x => x.active == 2).Select(x =>
                //  new UserViewModel
                //  {
                //      Id = x.id,
                //      active = x.active,
                //      username = x.username,
                //  }
                //  ).Skip((page - 1) * limit).Take(limit).ToList();
                //var count = context.Users.Where(x => x.active == 2).Count();
                var count = queryList.Count();
                int pageCount = Convert.ToInt32(Math.Ceiling((double)count / limit));


                var result = new PagedResult<UserViewModel>();
                result.activePage = page;
                result.limit = limit;
                result.count = count;
                result.Results = query;
                result.countPage = pageCount;

                return result;
                //return context.Users.Where(x => x.active == 2).Select(x => new UserViewModel { Id = x.id, username = x.username, 
                //    active = x.active,Count = context.Users.Where(x => x.active == 2).Count() }).Skip((page-1)*limit).Take(limit).ToList();
            }

        }

        public User GetSavedRefreshTokens(string username, string refreshToken)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(x => x.username == username && x.refreshtoken == refreshToken && x.active == 2);
            }
        }

        public User GetSavedRefreshTokensWithRefresh(string refreshToken)
        {
            using (var context = new Context())
            {
                return context.Users.FirstOrDefault(x => x.refreshtoken == refreshToken && x.active == 2);
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
