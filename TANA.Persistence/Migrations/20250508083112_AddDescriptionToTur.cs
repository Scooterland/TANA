using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TANA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToTur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Turer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Turer");
        }
    }
}
