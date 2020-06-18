using Microsoft.EntityFrameworkCore.Migrations;

namespace GlrTransportInc.Data.Migrations
{
    public partial class PhoneNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone2",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone3",
                table: "FreightBill",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone2",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "phone3",
                table: "FreightBill");
        }
    }
}
