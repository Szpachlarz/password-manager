using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManager.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedColsForAESFix2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AES_IV",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AES_IV",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
