using Assel.DTO;
using Assel.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            return Ok(await _userService.GetAll());
        }
    }
}
