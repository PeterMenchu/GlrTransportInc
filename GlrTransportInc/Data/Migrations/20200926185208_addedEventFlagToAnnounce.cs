using Microsoft.EntityFrameworkCore.Migrations;

namespace GlrTransportInc.Data.Migrations
{
    public partial class addedEventFlagToAnnounce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "eventFlag",
                table: "Announcement",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "eventFlag",
                table: "Announcement");
        }
    }
}
