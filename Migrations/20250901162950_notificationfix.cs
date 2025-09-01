using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzadmin.Migrations
{
    /// <inheritdoc />
    public partial class notificationfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "024b5a49-7be1-4c0c-b2ac-61d5abfe82bd", "AQAAAAIAAYagAAAAEF0WdJR98bKvCSxRWBz7+dBxZC1z2PnXhUEypINaEgMNEyZu+tjPeDvp4yYaDqm4WA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00242d4f-c80c-4dfa-ae08-828a5fc9ca14", "AQAAAAIAAYagAAAAEFq2HUCbkYZJV9Y0yVkFLXi6rmywJC2iFQqvMfu2+HOqzF+4fklvtpvLHl/djUmrCw==" });
        }
    }
}
