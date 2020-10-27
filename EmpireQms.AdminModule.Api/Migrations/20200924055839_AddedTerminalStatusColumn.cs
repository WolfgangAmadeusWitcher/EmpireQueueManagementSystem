using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.AdminModule.Api.Migrations
{
    public partial class AddedTerminalStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Terminals",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Terminals");
        }
    }
}
