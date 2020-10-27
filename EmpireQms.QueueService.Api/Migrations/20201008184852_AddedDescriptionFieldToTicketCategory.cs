using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.QueueService.Api.Migrations
{
    public partial class AddedDescriptionFieldToTicketCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TicketCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "TicketCategories");
        }
    }
}
