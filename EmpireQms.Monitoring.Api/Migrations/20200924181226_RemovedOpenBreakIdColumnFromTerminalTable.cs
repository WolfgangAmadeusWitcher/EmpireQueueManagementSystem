using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.Monitoring.Api.Migrations
{
    public partial class RemovedOpenBreakIdColumnFromTerminalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenBreakId",
                table: "Terminals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OpenBreakId",
                table: "Terminals",
                type: "int",
                nullable: true);
        }
    }
}
