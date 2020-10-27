using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.Monitoring.Api.Migrations
{
    public partial class RemoveTicketCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketCategoryName",
                table: "EmpireQueues");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "EmpireQueues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "EmpireQueues");

            migrationBuilder.AddColumn<string>(
                name: "TicketCategoryName",
                table: "EmpireQueues",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
