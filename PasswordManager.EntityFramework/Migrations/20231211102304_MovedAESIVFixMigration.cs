using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManager.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class MovedAESIVFixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AesIV",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AesIV",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
