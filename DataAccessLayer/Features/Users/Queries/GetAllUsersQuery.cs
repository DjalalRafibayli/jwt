using AnotherModel.FilterModels.User;
using DataAccessLayer.Abstract.Users;
using DataAccessLayer.Models.Page;
using EfCodeFirst.Models.ViewModels;
using EntityLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.Features.Users.Queries
{
    public class GetAllUsersQuery : IRequest<PagedResult<UserViewModel>>
    {
        public UserFM UserFM { get; set; }
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedResult<UserViewModel>>
        {
            private readonly IUserDal _userDal;

            public GetAllUsersQueryHandler(IUserDal userDal)
            {
                _userDal = userDal;
            }

            public async Task<PagedResult<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                return await _userDal.GetAllUsers(request.UserFM);
            }
        }
    }
}
