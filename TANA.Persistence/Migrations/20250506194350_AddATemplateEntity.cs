using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TANA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddATemplateEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefinitionJson",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "IsSystemTemplate",
                table: "Templates");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Templates");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Templates",
                newName: "TemplateName");

            migrationBuilder.CreateTable(
                name: "TemplateItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    TemplateEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateItems_Templates_TemplateEntityId",
                        column: x => x.TemplateEntityId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateItems_TemplateEntityId",
                table: "TemplateItems",
                column: "TemplateEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateItems");

            migrationBuilder.RenameColumn(
                name: "TemplateName",
                table: "Templates",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "DefinitionJson",
                table: "Templates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Templates",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
