using AnotherModel.FilterModels.User;
using DataAccessLayer.Features.Users.Queries;
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

        [HttpGet("GetAllUsers/{page}/{limit}")]
        public async Task<IActionResult> GetAllUsers(int page, int limit, [FromQuery] UserFM userFM)
        {
            page = page == 0 ? 1 : page;

            limit = limit == 0 ? 10 : limit;
            var query = new GetAllUsersQuery() { page = page, limit = limit, UserFM = userFM };
            return Ok(await _mediator.Send(query));
        }
    }
}
