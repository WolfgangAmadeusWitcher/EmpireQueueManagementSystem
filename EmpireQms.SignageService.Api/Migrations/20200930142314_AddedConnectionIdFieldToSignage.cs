using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.SignageService.Api.Migrations
{
    public partial class AddedConnectionIdFieldToSignage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConnectionIds",
                table: "Signages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionIds",
                table: "Signages");
        }
    }
}
