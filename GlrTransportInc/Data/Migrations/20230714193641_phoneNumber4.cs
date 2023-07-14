using Microsoft.EntityFrameworkCore.Migrations;

namespace GlrTransportInc.Data.Migrations
{
    public partial class phoneNumber4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "phone4",
                table: "FreightBill",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phone4",
                table: "FreightBill");
        }
    }
}
