using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TicketDispenser.Api.Migrations
{
    public partial class RemovedLastEnqueuedTicketNumberField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastEnqueuedTicketNumber",
                table: "EmpireQueues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastEnqueuedTicketNumber",
                table: "EmpireQueues",
                type: "int",
                nullable: true);
        }
    }
}
