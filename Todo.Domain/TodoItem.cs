using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDO.Domain
{
    public class TodoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public DateTime AddedOn { get; set; }
        public Priority Priority { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }


    public enum Priority
    {
        low = 1,
        medium,
        high
    }
}