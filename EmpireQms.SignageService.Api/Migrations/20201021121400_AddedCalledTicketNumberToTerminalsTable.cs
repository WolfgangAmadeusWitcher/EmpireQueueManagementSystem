using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.SignageService.Api.Migrations
{
    public partial class AddedCalledTicketNumberToTerminalsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalledTicketNumber",
                table: "Terminals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalledTicketNumber",
                table: "Terminals");
        }
    }
}
