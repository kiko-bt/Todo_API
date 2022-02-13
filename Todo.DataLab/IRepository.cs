using Todo.Domain;

namespace NoteApp.DataAccess
{
    public interface IRepository<T>
    {
        Task<ServiceResponse<IEnumerable<T>>> GetAll();
        Task<ServiceResponse<T>> GetById(int id);
        Task<ServiceResponse<T>> Insert(T entity);
        Task<ServiceResponse<T>> Update(int id, T entity);
        Task<ServiceResponse<T>> Delete(T entity);
    }
}
