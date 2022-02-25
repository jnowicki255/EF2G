using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EF2G.Repository.Migrations
{
    public partial class UsersSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "ExpirationDate", "FirstName", "InsertDate", "LastLoginDate", "LastName", "ModifyDate", "Password", "Telephone", "Username" },
                values: new object[] { 1, "tester@example.com", null, "Test", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Er", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123", "555-666-777", "tester" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "ExpirationDate", "FirstName", "InsertDate", "LastLoginDate", "LastName", "ModifyDate", "Password", "Telephone", "Username" },
                values: new object[] { 2, "sampleUser@example.com", null, "Sample", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "123", "555-666-777", "sampleUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
