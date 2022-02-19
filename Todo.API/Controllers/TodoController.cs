using Microsoft.AspNetCore.Mvc;
using NoteApp.DataAccess;
using ToDO.Domain;


namespace Todo.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IRepository<TodoItem> _todoService;

        public TodoController(IRepository<TodoItem> todoService)
        {
            _todoService = todoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            try
            {
                return Ok(await _todoService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> Get(int id)
        {
            try
            {
                return Ok(await _todoService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong. {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<ActionResult<TodoItem>> Post([FromBody] TodoItem todoItem)
        {
            try
            {
                await _todoService.Insert(todoItem);
                return Ok("Successfully Added!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Add todo failed. {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TodoItem todoItem)
        {
            try
            {
                await _todoService.Update(id, todoItem);
                return Ok($"Successfully updated Todo!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Update todo failed. {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var todoItem = await _todoService.GetById(id);

                if (todoItem == null)
                {
                    return NotFound();
                }

                await _todoService.Delete(todoItem.Data);

                return Ok("Todo deleted successfully!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Delete todo failed. {ex.Message}");
            }
        }
    }
}
