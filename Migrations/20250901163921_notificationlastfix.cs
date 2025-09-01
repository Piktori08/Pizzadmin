using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzadmin.Migrations
{
    /// <inheritdoc />
    public partial class notificationlastfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e8934c2-245b-4a80-accf-847b6d6bfb60", "AQAAAAIAAYagAAAAEDXYzkrDw1PRDXHKv/UmwiZLejdyfkA03gSVjK6Ipl7sr9fggi3IUEmPezKtHKCDjQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7353f5df-7a6f-48bb-b4ae-6a8ebee21615", "AQAAAAIAAYagAAAAEJRFA3/63iNoIaoqFGbc/fTCSy0Uq4qncjk/8dgTp7+lrZ6crFclcQczDlzs0mCrjg==" });
        }
    }
}
