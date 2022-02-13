using Microsoft.EntityFrameworkCore;
using NoteApp.DataAccess;
using Todo.Domain;
using ToDO.Domain;

namespace Todo.DataLab.Repositories
{
    public class TodoRepository : BaseRepository, IRepository<TodoItem>
    {
        public TodoRepository(ToDoDBContext db) : base(db) { }

        public async Task<ServiceResponse<IEnumerable<TodoItem>>> GetAll()
        {
            ServiceResponse<IEnumerable<TodoItem>> serviceResponse = new();
            serviceResponse.Data = await _db.Todos.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<TodoItem>> GetById(int id)
        {
            ServiceResponse<TodoItem> serviceResponse = new();
            serviceResponse.Data = await _db.Todos.FirstOrDefaultAsync(x => x.Id == id);
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<TodoItem>> Insert(TodoItem entity)
        {
            ServiceResponse<TodoItem> serviceResponse = new();

            if (entity == null)
                throw new ArgumentOutOfRangeException(nameof(entity));

            await _db.Todos.AddAsync(entity);
            await _db.SaveChangesAsync();
            serviceResponse.Data = entity;

            return serviceResponse;
        }

        public async Task<ServiceResponse<TodoItem>> Update(int id, TodoItem entity)
        {
            ServiceResponse<TodoItem> serviceResponse = new();

            if (entity == null)
                throw new ArgumentOutOfRangeException(nameof(entity));

            var todo = await _db.Todos.SingleOrDefaultAsync(x => x.Id == id);

            if (todo != null)
            {
                todo.Name = entity.Name;
                todo.IsComplete = entity.IsComplete;
                todo.AddedOn = entity.AddedOn;
                todo.Priority = entity.Priority;
                todo.UserId = entity.UserId;

                await _db.SaveChangesAsync();
            }

            serviceResponse.Data = todo;

            return serviceResponse;
        }

        public async Task<ServiceResponse<TodoItem>> Delete(TodoItem entity)
        {
            ServiceResponse<TodoItem> serviceResponse = new();

            if (entity == null)
                throw new ArgumentOutOfRangeException(nameof(entity));

            _db.Todos.Remove(entity);
            await _db.SaveChangesAsync();

            serviceResponse.Data = entity;

            return serviceResponse;
        }
    }
}
