namespace Todo.DomainModels
{
    public class TodoItemDTO
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTime AddedOn { get; set; }
        public PriorityDTO Priority { get; set; }
        public int UserId { get; set; }
        public UserDTO User { get; set; }
    }

    public enum PriorityDTO
    {
        low = 1,
        medium,
        high
    }
}
