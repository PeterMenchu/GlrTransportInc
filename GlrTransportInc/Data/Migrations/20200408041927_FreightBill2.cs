using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GlrTransportInc.Data.Migrations
{
    public partial class FreightBill2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "FromLocation",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "FreightBill");

            migrationBuilder.AddColumn<string>(
                name: "BranchAndDescription",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletionDate",
                table: "FreightBill",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "Cost1",
                table: "FreightBill",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cost2",
                table: "FreightBill",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cost3",
                table: "FreightBill",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cost4",
                table: "FreightBill",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cost5",
                table: "FreightBill",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cost6",
                table: "FreightBill",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cost7",
                table: "FreightBill",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cost8",
                table: "FreightBill",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Cost9",
                table: "FreightBill",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "DocJob",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "FreightBill",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FreightBillNumber",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromCity",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromName",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromState",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromStreet",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromZip",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Labor1",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Labor2",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Labor3",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Labor4",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Labor5",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Labor6",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Labor7",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Labor8",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Labor9",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceivedBy",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduledDate",
                table: "FreightBill",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SiteName",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SitePhoneNumber",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToName",
                table: "FreightBill",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "FreightBill",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchAndDescription",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "CompletionDate",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Cost1",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Cost2",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Cost3",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Cost4",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Cost5",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Cost6",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Cost7",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Cost8",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Cost9",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "DocJob",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "FreightBillNumber",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "FromCity",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "FromName",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "FromState",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "FromStreet",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "FromZip",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Labor1",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Labor2",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Labor3",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Labor4",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Labor5",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Labor6",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Labor7",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Labor8",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Labor9",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "ReceivedBy",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "SiteName",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "SitePhoneNumber",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "ToName",
                table: "FreightBill");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "FreightBill");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "FreightBill",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FromLocation",
                table: "FreightBill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "FreightBill",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
