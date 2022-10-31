using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraVirtualTour.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffModel_AppFile_Imageid",
                table: "StaffModel");

            migrationBuilder.DropTable(
                name: "AppFile");

            migrationBuilder.DropIndex(
                name: "IX_StaffModel_Imageid",
                table: "StaffModel");

            migrationBuilder.DropColumn(
                name: "Imageid",
                table: "StaffModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Imageid",
                table: "StaffModel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppFile",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Content = table.Column<byte[]>(type: "BLOB", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFile", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StaffModel_Imageid",
                table: "StaffModel",
                column: "Imageid");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffModel_AppFile_Imageid",
                table: "StaffModel",
                column: "Imageid",
                principalTable: "AppFile",
                principalColumn: "id");
        }
    }
}
