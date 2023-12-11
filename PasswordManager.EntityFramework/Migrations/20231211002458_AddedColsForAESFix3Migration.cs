using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManager.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedColsForAESFix3Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AesKey",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");

            migrationBuilder.AlterColumn<string>(
                name: "AesIV",
                table: "Users",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "BLOB");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "AesKey",
                table: "Users",
                type: "BLOB",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<byte[]>(
                name: "AesIV",
                table: "Users",
                type: "BLOB",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
