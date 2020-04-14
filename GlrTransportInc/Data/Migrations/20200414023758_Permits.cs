using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GlrTransportInc.Data.Migrations
{
    public partial class Permits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Permit",
                table: "FreightBill",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permit",
                table: "FreightBill");
        }
    }
}
