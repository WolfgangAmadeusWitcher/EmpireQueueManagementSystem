using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.Monitoring.Api.Migrations
{
    public partial class ChangedTicketCategoryIdToCategoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketCategoryId",
                table: "EmpireQueues");

            migrationBuilder.AddColumn<string>(
                name: "TicketCategoryName",
                table: "EmpireQueues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketCategoryName",
                table: "EmpireQueues");

            migrationBuilder.AddColumn<int>(
                name: "TicketCategoryId",
                table: "EmpireQueues",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
