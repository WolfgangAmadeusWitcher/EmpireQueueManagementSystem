using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.QueueService.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpireQueues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketCategoryId = table.Column<int>(nullable: false),
                    QueueWeight = table.Column<double>(nullable: false),
                    MaxAllowedCustomers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpireQueues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerminalCategories",
                columns: table => new
                {
                    TerminalId = table.Column<int>(nullable: false),
                    TicketCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalCategories", x => new { x.TerminalId, x.TicketCategoryId });
                });

            migrationBuilder.CreateTable(
                name: "TicketCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PriorityCoefficient = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    QueueId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    TicketCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpireQueues");

            migrationBuilder.DropTable(
                name: "TerminalCategories");

            migrationBuilder.DropTable(
                name: "TicketCategories");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
