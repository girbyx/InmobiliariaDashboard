using Microsoft.EntityFrameworkCore.Migrations;

namespace InmobiliariaDashboard.Server.Migrations
{
    public partial class AddLocationColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Contacts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Contacts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Contacts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Zip",
                table: "Contacts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Clients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Clients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Clients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Zip",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Clients");
        }
    }
}
