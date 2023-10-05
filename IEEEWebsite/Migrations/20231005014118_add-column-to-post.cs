using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IEEEWebsite.Migrations
{
    /// <inheritdoc />
    public partial class addcolumntopost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaceBookLink",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkedInLink",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FaceBookLink",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkedInLink",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceBookLink",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "LinkedInLink",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "FaceBookLink",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LinkedInLink",
                table: "Events");
        }
    }
}
