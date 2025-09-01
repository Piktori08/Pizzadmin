using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzadmin.Migrations
{
    /// <inheritdoc />
    public partial class notificationfixfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7353f5df-7a6f-48bb-b4ae-6a8ebee21615", "AQAAAAIAAYagAAAAEJRFA3/63iNoIaoqFGbc/fTCSy0Uq4qncjk/8dgTp7+lrZ6crFclcQczDlzs0mCrjg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "024b5a49-7be1-4c0c-b2ac-61d5abfe82bd", "AQAAAAIAAYagAAAAEF0WdJR98bKvCSxRWBz7+dBxZC1z2PnXhUEypINaEgMNEyZu+tjPeDvp4yYaDqm4WA==" });
        }
    }
}
