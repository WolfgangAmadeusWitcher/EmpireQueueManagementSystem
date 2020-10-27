using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TerminalService.Api.Migrations
{
    public partial class RenameTerminalIdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakLogs_Terminals_TerminalId",
                table: "BreakLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terminals",
                table: "Terminals");

            migrationBuilder.DropColumn(
                name: "TerminalId",
                table: "Terminals");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Terminals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terminals",
                table: "Terminals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BreakLogs_Terminals_TerminalId",
                table: "BreakLogs",
                column: "TerminalId",
                principalTable: "Terminals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakLogs_Terminals_TerminalId",
                table: "BreakLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Terminals",
                table: "Terminals");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Terminals");

            migrationBuilder.AddColumn<int>(
                name: "TerminalId",
                table: "Terminals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Terminals",
                table: "Terminals",
                column: "TerminalId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreakLogs_Terminals_TerminalId",
                table: "BreakLogs",
                column: "TerminalId",
                principalTable: "Terminals",
                principalColumn: "TerminalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
