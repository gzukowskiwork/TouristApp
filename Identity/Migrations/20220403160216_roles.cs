using Microsoft.EntityFrameworkCore.Migrations;

namespace Identity.Migrations
{
    public partial class roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ff9d5f2-7b77-4d0f-951a-b5e2d4dbfae0", "39695e1c-f754-47e7-b2ce-f0ed983d0e8c", "RegisteredUser", "REGISTEREDUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bcb639f3-af0e-4c9c-8493-06da54921c3b", "60c77aac-74a0-4c11-9b31-c3c724f5a9f5", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ff9d5f2-7b77-4d0f-951a-b5e2d4dbfae0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bcb639f3-af0e-4c9c-8493-06da54921c3b");
        }
    }
}
