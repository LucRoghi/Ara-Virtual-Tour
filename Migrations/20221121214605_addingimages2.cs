using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraVirtualTour.Migrations
{
    public partial class addingimages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "StaffModel",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Filename",
                table: "StaffModel",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "StaffModel");

            migrationBuilder.DropColumn(
                name: "Filename",
                table: "StaffModel");
        }
    }
}
