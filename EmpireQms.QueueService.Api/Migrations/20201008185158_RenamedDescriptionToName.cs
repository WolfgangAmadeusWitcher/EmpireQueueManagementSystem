using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.QueueService.Api.Migrations
{
    public partial class RenamedDescriptionToName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TicketCategories");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TicketCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TicketCategories");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TicketCategories",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
