using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TerminalService.Api.Migrations
{
    public partial class RenameBreakLogsToBreakLogEntries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakLogs_Terminals_TerminalId",
                table: "BreakLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BreakLogs",
                table: "BreakLogs");

            migrationBuilder.RenameTable(
                name: "BreakLogs",
                newName: "BreakLogEntries");

            migrationBuilder.RenameIndex(
                name: "IX_BreakLogs_TerminalId",
                table: "BreakLogEntries",
                newName: "IX_BreakLogEntries_TerminalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BreakLogEntries",
                table: "BreakLogEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BreakLogEntries_Terminals_TerminalId",
                table: "BreakLogEntries",
                column: "TerminalId",
                principalTable: "Terminals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreakLogEntries_Terminals_TerminalId",
                table: "BreakLogEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BreakLogEntries",
                table: "BreakLogEntries");

            migrationBuilder.RenameTable(
                name: "BreakLogEntries",
                newName: "BreakLogs");

            migrationBuilder.RenameIndex(
                name: "IX_BreakLogEntries_TerminalId",
                table: "BreakLogs",
                newName: "IX_BreakLogs_TerminalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BreakLogs",
                table: "BreakLogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BreakLogs_Terminals_TerminalId",
                table: "BreakLogs",
                column: "TerminalId",
                principalTable: "Terminals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
