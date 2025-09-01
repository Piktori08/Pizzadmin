using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzadmin.Migrations
{
    /// <inheritdoc />
    public partial class notifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Position" },
                values: new object[] { "00242d4f-c80c-4dfa-ae08-828a5fc9ca14", "AQAAAAIAAYagAAAAEFq2HUCbkYZJV9Y0yVkFLXi6rmywJC2iFQqvMfu2+HOqzF+4fklvtpvLHl/djUmrCw==", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Position" },
                values: new object[] { "c2d1cf73-7ce3-465c-a1cd-2b80919f3607", "AQAAAAIAAYagAAAAEO+csVL5x7Rw/hkq04G6lJ+i3nML6m3e98hED5ytjmVYoavviV09Y8O27En/iWUDJw==", null });
        }
    }
}
