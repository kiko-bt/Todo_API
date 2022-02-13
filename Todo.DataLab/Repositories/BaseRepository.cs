namespace Todo.DataLab.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ToDoDBContext _db;

        public BaseRepository(ToDoDBContext db)
        {
            _db = db;
        }
    }
}
