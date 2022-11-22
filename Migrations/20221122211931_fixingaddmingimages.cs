using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AraVirtualTour.Migrations
{
    public partial class fixingaddmingimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "StaffModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "StaffModel",
                type: "BLOB",
                nullable: true);
        }
    }
}
