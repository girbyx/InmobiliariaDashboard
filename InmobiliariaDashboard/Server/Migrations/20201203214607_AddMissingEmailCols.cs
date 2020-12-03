using Microsoft.EntityFrameworkCore.Migrations;

namespace InmobiliariaDashboard.Server.Migrations
{
    public partial class AddMissingEmailCols : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clients",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clients");
        }
    }
}
