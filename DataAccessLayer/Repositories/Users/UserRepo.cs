using DataAccessLayer.Abstract.Users;
using DataAccessLayer.Concrete;
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
    }
}
