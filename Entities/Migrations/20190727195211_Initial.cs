using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedAt", "Email", "FirstName", "Gender", "LastName", "PhoneNumber", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "feruchio599@gmail.com", "Maverick", "Male", "Cloud", "088-61-62-835", new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maverick" },
                    { 2, new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "saad@gmail.com", "Saad", "Male", "Salim", "999-888-7777", new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saad" },
                    { 3, new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "xinoredm@gmail.com", "Xinored", "Male", "Deronix", "939-858-7977", new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xinored" },
                    { 4, new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "badboy@gmail.com", "Badboy", "Male", "Boy", "989-158-7877", new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Badboy" },
                    { 5, new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "roller@gmail.com", "Roller", "Male", "Rolls", "039-855-7927", new DateTime(2019, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mr.Roller" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
