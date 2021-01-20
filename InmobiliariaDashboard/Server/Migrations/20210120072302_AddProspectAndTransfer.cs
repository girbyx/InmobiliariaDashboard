using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InmobiliariaDashboard.Server.Migrations
{
    public partial class AddProspectAndTransfer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Prospect",
                table: "Projects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "CostBankAccountId",
                table: "Gains",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Transfer",
                table: "Gains",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "GainBankAccountId",
                table: "Costs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Transfer",
                table: "Costs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 20, 1, 23, 2, 466, DateTimeKind.Local).AddTicks(9309));

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 20, 1, 23, 2, 470, DateTimeKind.Local).AddTicks(4453));

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 20, 1, 23, 2, 470, DateTimeKind.Local).AddTicks(4580));

            migrationBuilder.CreateIndex(
                name: "IX_Gains_CostBankAccountId",
                table: "Gains",
                column: "CostBankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_GainBankAccountId",
                table: "Costs",
                column: "GainBankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_BankAccounts_GainBankAccountId",
                table: "Costs",
                column: "GainBankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gains_BankAccounts_CostBankAccountId",
                table: "Gains",
                column: "CostBankAccountId",
                principalTable: "BankAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_BankAccounts_GainBankAccountId",
                table: "Costs");

            migrationBuilder.DropForeignKey(
                name: "FK_Gains_BankAccounts_CostBankAccountId",
                table: "Gains");

            migrationBuilder.DropIndex(
                name: "IX_Gains_CostBankAccountId",
                table: "Gains");

            migrationBuilder.DropIndex(
                name: "IX_Costs_GainBankAccountId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "Prospect",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "CostBankAccountId",
                table: "Gains");

            migrationBuilder.DropColumn(
                name: "Transfer",
                table: "Gains");

            migrationBuilder.DropColumn(
                name: "GainBankAccountId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "Transfer",
                table: "Costs");

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 20, 7, 7, 81, DateTimeKind.Local).AddTicks(5457));

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 20, 7, 7, 84, DateTimeKind.Local).AddTicks(9595));

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 1, 19, 20, 7, 7, 84, DateTimeKind.Local).AddTicks(9716));
        }
    }
}
