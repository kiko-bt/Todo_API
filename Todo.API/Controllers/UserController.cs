using Microsoft.AspNetCore.Mvc;
using NoteApp.DataAccess;
using ToDO.Domain;


namespace Todo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _userService;

        public UserController(IRepository<User> userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            try
            {
                return Ok(await _userService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                return Ok(await _userService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            try
            {
                await _userService.Insert(user);
                return Ok("Successfully added!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Add user failed. {ex.Message}");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User user)
        {
            try
            {
                await _userService.Update(id, user);
                return Ok("Successfully updated User!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Update user failed. {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var user = await _userService.GetById(id);

                if (user == null)
                {
                    return NotFound();
                }

                await _userService.Delete(user.Data);
                return Ok("User deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Delete user failed. {ex.Message}");
            }
        }
    }
}
