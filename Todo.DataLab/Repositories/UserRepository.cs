using Microsoft.EntityFrameworkCore;
using NoteApp.DataAccess;
using Todo.Domain;
using ToDO.Domain;

namespace Todo.DataLab.Repositories
{
    public class UserRepository : BaseRepository, IRepository<User>
    {
        public UserRepository(ToDoDBContext db) : base(db) { }

        public async Task<ServiceResponse<IEnumerable<User>>> GetAll()
        {
            ServiceResponse<IEnumerable<User>> serviceResponse = new();
            serviceResponse.Data = await _db.Users.ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> GetById(int id)
        {
            ServiceResponse<User> serviceResponse = new();

            serviceResponse.Data = await _db.Users.FindAsync(id);

            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> Insert(User entity)
        {
            ServiceResponse<User> serviceResponse = new();

            if (entity == null)
                throw new ArgumentOutOfRangeException(nameof(entity));

            _db.Users.Add(entity);
            await _db.SaveChangesAsync();
            serviceResponse.Data = entity;

            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> Update(int id, User entity)
        {
            ServiceResponse<User> serviceResponse = new();

            if (entity == null)
                throw new ArgumentOutOfRangeException(nameof(entity));

            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;
                user.Username = entity.Username;
                user.Password = entity.Password;
                user.TodoId = entity.TodoId;
                user.Todos = entity.Todos;

                _db.SaveChanges();
            }


            serviceResponse.Data = user;

            return serviceResponse;
        }

        public async Task<ServiceResponse<User>> Delete(User entity)
        {
            ServiceResponse<User> serviceResponse = new();

            if (entity == null)
                throw new ArgumentOutOfRangeException(nameof(entity));


            _db.Users.Remove(entity);
            await _db.SaveChangesAsync();

            serviceResponse.Data = entity;

            return serviceResponse;
        }
    }
}
