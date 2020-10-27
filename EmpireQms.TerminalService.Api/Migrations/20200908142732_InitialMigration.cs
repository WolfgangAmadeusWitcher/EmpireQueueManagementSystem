using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TerminalService.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    TerminalId = table.Column<int>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ConnectionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.TerminalId);
                });

            migrationBuilder.CreateTable(
                name: "BreakLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BreakReason = table.Column<string>(nullable: true),
                    BreakStartTime = table.Column<DateTime>(nullable: false),
                    BreakEndTime = table.Column<DateTime>(nullable: false),
                    TerminalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreakLogs_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "TerminalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreakLogs_TerminalId",
                table: "BreakLogs",
                column: "TerminalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakLogs");

            migrationBuilder.DropTable(
                name: "Terminals");
        }
    }
}
