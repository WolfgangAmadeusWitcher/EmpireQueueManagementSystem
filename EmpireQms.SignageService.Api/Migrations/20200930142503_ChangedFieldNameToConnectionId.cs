using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.SignageService.Api.Migrations
{
    public partial class ChangedFieldNameToConnectionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionIds",
                table: "Signages");

            migrationBuilder.AddColumn<string>(
                name: "ConnectionId",
                table: "Signages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionId",
                table: "Signages");

            migrationBuilder.AddColumn<string>(
                name: "ConnectionIds",
                table: "Signages",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
