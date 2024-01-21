using Microsoft.AspNetCore.Mvc;
using Store.Domain.Interface;
using Store.Domain.Requests.User;

namespace Store.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
        {
            await _userService.CreateUserAsync(request);
            return Ok();
        }
    }
}
