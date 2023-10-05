using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IEEEWebsite.Migrations
{
    /// <inheritdoc />
    public partial class addWarningModelupdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Warnings");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Warnings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Warnings");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Warnings",
                type: "int",
                nullable: true);
        }
    }
}
