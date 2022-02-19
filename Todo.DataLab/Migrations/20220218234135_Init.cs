using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.DataLab.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TodoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "TodoId", "Username" },
                values: new object[] { 1, "Hristijan", "Petrovski", "l|??d$fV???5?	", 2, "kiko-bt" });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AddedOn", "IsComplete", "Name", "Priority", "UserId" },
                values: new object[] { 1, new DateTime(2022, 2, 20, 0, 41, 35, 575, DateTimeKind.Local).AddTicks(9149), true, "Make an order from Asos", 1, 1 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AddedOn", "IsComplete", "Name", "Priority", "UserId" },
                values: new object[] { 2, new DateTime(2022, 3, 3, 0, 41, 35, 575, DateTimeKind.Local).AddTicks(9176), false, "Implement Web API project", 3, 1 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AddedOn", "IsComplete", "Name", "Priority", "UserId" },
                values: new object[] { 3, new DateTime(2022, 2, 19, 0, 41, 35, 575, DateTimeKind.Local).AddTicks(9178), true, "Go to gym", 3, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Todos_UserId",
                table: "Todos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
