using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TANA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSummaryToTemplateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Templates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Templates");
        }
    }
}
