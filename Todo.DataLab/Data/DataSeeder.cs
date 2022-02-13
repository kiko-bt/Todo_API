using System.Text;
using ToDO.Domain;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

public static class DataSeeder
{
    public static void SeedData(ModelBuilder modelBuilder)
    {
        var md5 = new MD5CryptoServiceProvider()
             .ComputeHash(Encoding.ASCII.GetBytes("loginfree"));
        var hashedPassword = Encoding.ASCII.GetString(md5);



        modelBuilder.Entity<TodoItem>()
                    .HasData(
                        new TodoItem
                        {
                            Id = 1,
                            Name = "Make an order from Asos",
                            IsComplete = true,
                            Priority = Priority.low,
                            AddedOn = DateTime.Now.AddDays(1),
                            UserId = 1,
                        },
                        new TodoItem
                        {
                            Id = 2,
                            Name = "Implement Web API project",
                            IsComplete = false,
                            Priority = Priority.high,
                            AddedOn = DateTime.Now.AddDays(12),
                            UserId = 1,
                        },
                        new TodoItem
                        {
                            Id = 3,
                            Name = "Go to gym",
                            IsComplete = true,
                            Priority = Priority.high,
                            AddedOn = DateTime.Now,
                            UserId = 1,
                        });

        modelBuilder.Entity<User>()
                    .HasData(
                        new User
                        {
                            Id = 1,
                            FirstName = "Hristijan",
                            LastName = "Petrovski",
                            Username = "kiko-bt",
                            Password = hashedPassword,
                            TodoId = 2
                        });
    }
}