using AnotherModel.FilterModels.User;
using DataAccessLayer.Features.Users.Commands;
using DataAccessLayer.Features.Users.Queries;
using DataAccessLayer.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EfCodeFirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(UserFM userFM)
        {
            userFM.page = userFM.page == 0 ? 1 : userFM.page;

            userFM.limit = userFM.limit == 0 ? 10 : userFM.limit;

            var query = new GetAllUsersQuery() { UserFM = userFM };
            return Ok(await _mediator.Send(query));
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(AddUser addUser)
        {
            addUser.active = 2;

            var query = new AddUserCommand() { AddUser = addUser };
            return Ok(await _mediator.Send(query));
        }
    }
}
