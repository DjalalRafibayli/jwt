using DataAccessLayer.Abstract.Users;
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
    public class GetAllUsersQuery : IRequest<IEnumerable<UserViewModel>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserViewModel>>
        {
            private readonly IUserDal _userDal;

            public GetAllUsersQueryHandler(IUserDal userDal)
            {
                _userDal = userDal;
            }

            public async Task<IEnumerable<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                return await _userDal.GetAllUsers();
            }
        }
    }
}
