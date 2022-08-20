using DataAccessLayer.Abstract.Users;
using DataAccessLayer.Models.Users;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataAccessLayer.Features.Users.Commands
{
    public class AddUserCommand : IRequest
    {
        public AddUser AddUser { get; set; }

        public class CommandValidator : AbstractValidator<AddUser>
        {
            public CommandValidator()
            {
                RuleFor(x => x.username)
                    .MinimumLength(5)
                    .MaximumLength(50)
                    .NotNull()
                    .NotEmpty();

                RuleFor(x => x.password)
                    .MinimumLength(5)
                    .MaximumLength(50)
                    .NotNull()
                    .NotEmpty();
            }
        }

        public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
        {
            private readonly IUserDal _userDal;

            public AddUserCommandHandler(IUserDal userDal)
            {
                _userDal = userDal;
            }

            public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                string response = await _userDal.AddUser(request.AddUser);
                if (response == "Bele bir user movcuddur")
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent(string.Format("Bele bir user movcuddur")),
                    };
                    throw new HttpResponseException(resp);
                }

                return Unit.Value;
            }
        }
    }
}

