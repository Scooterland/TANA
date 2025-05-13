using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TANA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Navn",
                table: "Templates",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "JsonDefinition",
                table: "Templates",
                newName: "DefinitionJson");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Templates",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystemTemplate",
                table: "Templates",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "IsSystemTemplate",
                table: "Templates");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Templates",
                newName: "Navn");

            migrationBuilder.RenameColumn(
                name: "DefinitionJson",
                table: "Templates",
                newName: "JsonDefinition");
        }
    }
}
