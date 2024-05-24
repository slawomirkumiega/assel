using Microsoft.AspNetCore.Mvc;
using users.DTO;
using users.Services;

namespace users.Controllers
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

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post(UserDto user)
        {
            await _userService.Add(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {          
            await _userService.Delete(id);
            return NoContent();
        }
    }
}
