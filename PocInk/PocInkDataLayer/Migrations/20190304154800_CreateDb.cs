using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocInkDAL.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InkDrawings",
                columns: table => new
                {
                    DrawingId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DrawingName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InkDrawings", x => x.DrawingId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    HashedPassword = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashedPassword", "Role", "UserName" },
                values: new object[] { new Guid("15215b0e-ca81-4ba7-b829-2fe2e397a6a1"), "Shakespeare@yahoo.com", "MXxgg2ygTwY7KlhyeTZrrgHA0DjYg2r93SKt1pmfASI=", "Admin", "William" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashedPassword", "Role", "UserName" },
                values: new object[] { new Guid("04d38a16-924f-47a8-a53d-0f9b3eebc7df"), "John@yahoo.com", "JUZ3HfuAnPDLx5YkeEDcLoe/JXTgre2BUai1nhQ+rWA=", "", "John" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InkDrawings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
