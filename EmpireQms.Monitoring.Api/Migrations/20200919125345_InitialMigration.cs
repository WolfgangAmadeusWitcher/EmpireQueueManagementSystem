using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.Monitoring.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakLogEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    BreakReason = table.Column<string>(nullable: true),
                    BreakStartTime = table.Column<DateTime>(nullable: false),
                    BreakEndTime = table.Column<DateTime>(nullable: false),
                    TerminalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakLogEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Alias = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    OpenBreakId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreakLogEntries");

            migrationBuilder.DropTable(
                name: "Terminals");
        }
    }
}
