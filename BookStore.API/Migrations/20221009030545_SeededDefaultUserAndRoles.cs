using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.API.Migrations
{
    public partial class SeededDefaultUserAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ddf90a9c-e5b5-4c7d-a726-dcea74c31d02", "022985d1-f4e4-4ceb-a595-8a05780c3661", "Administrator", "ADMINISTRATOR" },
                    { "f006f943-8719-4f48-8a70-3326d230d5f1", "07647c59-0672-4f07-803f-12281f5095a6", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "93b72426-8409-4698-9326-ae0bf24576db", 0, "2173d93d-2027-4d85-be75-e81759e75f1c", "user@bookstore.com", false, "System", "USER", false, null, "USER@BOOKSTORE.COM", null, "AQAAAAEAACcQAAAAEH2iTSqjHuuQM9xd8qyC4OR635b0hd2XbxE123QF6xLjk6VnhSUB3U6IcYBXbhcTXQ==", null, false, "f3a6ce05-b46b-4488-9b10-42cd54c7ff15", false, "USERin@bookstore.com" },
                    { "acbfad13-1932-4bbb-8f05-39bf06c6c784", 0, "faa55832-101d-4ac1-b274-fb740b18c0aa", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", null, "AQAAAAEAACcQAAAAEKYEFfaoqCopk87M7Oa+jrV8rg9iAO4vJQi556eqXi+R4N5jizivK4PM5PALT7f92g==", null, false, "4e8b4aa9-5d95-471b-9403-8b32e41eaf28", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f006f943-8719-4f48-8a70-3326d230d5f1", "93b72426-8409-4698-9326-ae0bf24576db" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ddf90a9c-e5b5-4c7d-a726-dcea74c31d02", "acbfad13-1932-4bbb-8f05-39bf06c6c784" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f006f943-8719-4f48-8a70-3326d230d5f1", "93b72426-8409-4698-9326-ae0bf24576db" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ddf90a9c-e5b5-4c7d-a726-dcea74c31d02", "acbfad13-1932-4bbb-8f05-39bf06c6c784" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddf90a9c-e5b5-4c7d-a726-dcea74c31d02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f006f943-8719-4f48-8a70-3326d230d5f1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "93b72426-8409-4698-9326-ae0bf24576db");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acbfad13-1932-4bbb-8f05-39bf06c6c784");
        }
    }
}
