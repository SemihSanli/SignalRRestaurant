using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class mig_contact_colmn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactFooterOpenDays",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactFooterOpenDaysDescription",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactFooterOpenHours",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactFooterTitle",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactFooterOpenDays",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactFooterOpenDaysDescription",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactFooterOpenHours",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactFooterTitle",
                table: "Contacts");
        }
    }
}
