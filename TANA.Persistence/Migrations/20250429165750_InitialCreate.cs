using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TANA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adminer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brugere",
                columns: table => new
                {
                    BrugerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rolle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brugere", x => x.BrugerId);
                });

            migrationBuilder.CreateTable(
                name: "EmailSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kunder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonNr = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pris = table.Column<double>(type: "float", nullable: false),
                    Dage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rejser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    StartsDato = table.Column<DateOnly>(type: "date", nullable: false),
                    SlutsDato = table.Column<DateOnly>(type: "date", nullable: false),
                    Dage = table.Column<int>(type: "int", nullable: false),
                    Pris = table.Column<double>(type: "float", nullable: false),
                    Kommentar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KundeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rejser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rejser_Kunder_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fakturarer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Dato = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pris = table.Column<double>(type: "float", nullable: false),
                    RejseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakturarer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fakturarer_Rejser_RejseId",
                        column: x => x.RejseId,
                        principalTable: "Rejser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RejseTurer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    Pris = table.Column<double>(type: "float", nullable: false),
                    Dage = table.Column<int>(type: "int", nullable: false),
                    TurId = table.Column<int>(type: "int", nullable: false),
                    RejseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RejseTurer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RejseTurer_Rejser_RejseId",
                        column: x => x.RejseId,
                        principalTable: "Rejser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RejseTurer_Turer_TurId",
                        column: x => x.TurId,
                        principalTable: "Turer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fakturarer_RejseId",
                table: "Fakturarer",
                column: "RejseId");

            migrationBuilder.CreateIndex(
                name: "IX_Rejser_KundeId",
                table: "Rejser",
                column: "KundeId");

            migrationBuilder.CreateIndex(
                name: "IX_RejseTurer_RejseId",
                table: "RejseTurer",
                column: "RejseId");

            migrationBuilder.CreateIndex(
                name: "IX_RejseTurer_TurId",
                table: "RejseTurer",
                column: "TurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adminer");

            migrationBuilder.DropTable(
                name: "Brugere");

            migrationBuilder.DropTable(
                name: "EmailSettings");

            migrationBuilder.DropTable(
                name: "Fakturarer");

            migrationBuilder.DropTable(
                name: "RejseTurer");

            migrationBuilder.DropTable(
                name: "Rejser");

            migrationBuilder.DropTable(
                name: "Turer");

            migrationBuilder.DropTable(
                name: "Kunder");
        }
    }
}
