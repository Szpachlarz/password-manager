using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManager.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedColsForAES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "AesIV",
                table: "Users",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "AesKey",
                table: "Users",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AesIV",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AesKey",
                table: "Users");
        }
    }
}
