namespace Todo.DomainModels
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int TodoId { get; set; }
        public ICollection<TodoItemDTO> Todos { get; set; }
    }
}
