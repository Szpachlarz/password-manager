using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordManager.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class MovedAESIVMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AES_IV",
                table: "Records",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AES_IV",
                table: "Records");
        }
    }
}
