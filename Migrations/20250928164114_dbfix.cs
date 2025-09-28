using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzadmin.Migrations
{
    /// <inheritdoc />
    public partial class dbfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5657485a-04ee-43e1-8c75-a860dc80a29a", "AQAAAAIAAYagAAAAEMT/ABPMDQ0XEathFDfDpBj9SWzInEY4ECjpryQ5o4aj46yhLPiYffbxQTXM6AE8cw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3e8934c2-245b-4a80-accf-847b6d6bfb60", "AQAAAAIAAYagAAAAEDXYzkrDw1PRDXHKv/UmwiZLejdyfkA03gSVjK6Ipl7sr9fggi3IUEmPezKtHKCDjQ==" });
        }
    }
}
