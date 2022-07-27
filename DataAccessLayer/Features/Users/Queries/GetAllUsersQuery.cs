using DataAccessLayer.Abstract.Users;
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
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
        {
            private readonly IUserDal _userDal;

            public GetAllUsersQueryHandler(IUserDal userDal)
            {
                _userDal = userDal;
            }

            public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                return await _userDal.GetAllUsers();
            }
        }
    }
}
