using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace club.Migrations
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date_Debut",
                table: "Membre");

            migrationBuilder.DropColumn(
                name: "Date_Fin",
                table: "Membre");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Membre");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Membre");

            migrationBuilder.DropColumn(
                name: "Titre",
                table: "Membre");

            migrationBuilder.RenameColumn(
                name: "Adresse",
                table: "Locale",
                newName: "Classe");

            migrationBuilder.CreateTable(
                name: "Responsable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date_Debut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_Fin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MembreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsable_Membre_MembreId",
                        column: x => x.MembreId,
                        principalTable: "Membre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Responsable_MembreId",
                table: "Responsable",
                column: "MembreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responsable");

            migrationBuilder.RenameColumn(
                name: "Classe",
                table: "Locale",
                newName: "Adresse");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Debut",
                table: "Membre",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Fin",
                table: "Membre",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Membre",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Membre",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Titre",
                table: "Membre",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
