using ToDO.Domain;
using Microsoft.EntityFrameworkCore;

namespace Todo.DataLab
{
    public class ToDoDBContext : DbContext
    {
        public ToDoDBContext(DbContextOptions options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> Todos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>()
                        .HasOne(x => x.User)
                        .WithMany(x => x.Todos)
                        .HasForeignKey(x => x.UserId);


            DataSeeder.SeedData(modelBuilder);
        }
    }

}
