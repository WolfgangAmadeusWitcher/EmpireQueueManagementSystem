using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TerminalService.Api.Migrations
{
    public partial class ChangedOpenBreakIdTypeInTerminal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OpenBreakId",
                table: "Terminals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenBreakId",
                table: "Terminals");
        }
    }
}
