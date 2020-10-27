using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.QueueService.Api.Migrations
{
    public partial class AddedTerminalTicketsForManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketState",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketStatus",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TerminalTickets",
                columns: table => new
                {
                    TerminalId = table.Column<int>(nullable: false),
                    TicketId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalTickets", x => new { x.TerminalId, x.TicketId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerminalTickets");

            migrationBuilder.DropColumn(
                name: "TicketStatus",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "TicketState",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
