using Microsoft.EntityFrameworkCore.Migrations;

namespace GlrTransportInc.Data.Migrations
{
    public partial class FilesNEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "File2",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "file3",
                table: "FreightBill",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "File2",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "file3",
                table: "FreightBill");
        }
    }
}
