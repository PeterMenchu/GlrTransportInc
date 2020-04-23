using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GlrTransportInc.Data.Migrations
{
    public partial class TimesheetMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Announcement",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Post",
                table: "Announcement",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Timesheet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Week = table.Column<DateTime>(nullable: false),
                    Hours1 = table.Column<float>(nullable: false),
                    Hours2 = table.Column<float>(nullable: false),
                    Hours3 = table.Column<float>(nullable: false),
                    Hours4 = table.Column<float>(nullable: false),
                    Hours5 = table.Column<float>(nullable: false),
                    Jobs1 = table.Column<int>(nullable: false),
                    Jobs2 = table.Column<int>(nullable: false),
                    Jobs3 = table.Column<int>(nullable: false),
                    Jobs4 = table.Column<int>(nullable: false),
                    Jobs5 = table.Column<int>(nullable: false),
                    Comments1 = table.Column<string>(nullable: true),
                    Comments2 = table.Column<string>(nullable: true),
                    Comments3 = table.Column<string>(nullable: true),
                    Comments4 = table.Column<string>(nullable: true),
                    Comments5 = table.Column<string>(nullable: true),
                    TotalHours = table.Column<float>(nullable: false),
                    PerHour = table.Column<float>(nullable: false),
                    Over40PerHour = table.Column<float>(nullable: false),
                    Total = table.Column<int>(nullable: false),
                    PayDate = table.Column<DateTime>(nullable: false),
                    NetPay = table.Column<float>(nullable: false),
                    DaysOff = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timesheet", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Timesheet");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Announcement",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Post",
                table: "Announcement",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
