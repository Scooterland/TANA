using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TANA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTemplateStyling2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FontFamily",
                table: "Templates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FooterBgColor",
                table: "Templates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeaderBgColor",
                table: "Templates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Layout",
                table: "Templates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryColor",
                table: "Templates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FontFamily",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "FooterBgColor",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "HeaderBgColor",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Layout",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "PrimaryColor",
                table: "Templates");
        }
    }
}
