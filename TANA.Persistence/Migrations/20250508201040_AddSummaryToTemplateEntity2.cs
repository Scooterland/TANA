using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TANA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSummaryToTemplateEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Templates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Templates");
        }
    }
}
