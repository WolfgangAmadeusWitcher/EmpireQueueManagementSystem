using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.AdminModule.Api.Migrations
{
    public partial class RemovedSignageIdFieldFromTerminalsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignageId",
                table: "Terminals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SignageId",
                table: "Terminals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
