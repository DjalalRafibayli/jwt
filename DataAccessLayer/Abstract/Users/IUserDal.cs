﻿using EfCodeFirst.Models.ViewModels;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Users
{
    public interface IUserDal
    {
        bool CheckUserExist(string username, string password);
        bool CheckUsername(string username);
        Task<IEnumerable<UserViewModel>> GetAllUsers(int page , int limit);
        User GetSavedRefreshTokens(string username, string refreshtoken);
        void UpdateUserRefreshToken(string username, string refreshToken);
    }
}
