using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GlrTransportInc.Data.Migrations
{
    public partial class FreightBill : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FreightBill",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer = table.Column<string>(nullable: true),
                    Driver = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    FromLocation = table.Column<string>(nullable: true),
                    PoNumber = table.Column<string>(nullable: true),
                    TruckNumber = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    ToZip = table.Column<string>(nullable: true),
                    ToState = table.Column<string>(nullable: true),
                    ToStreet = table.Column<string>(nullable: true),
                    ToCity = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreightBill", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreightBill");
        }
    }
}
