using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.AdminModule.Api.Migrations
{
    public partial class AddedPriorityCoefficientColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PriorityCoefficient",
                table: "TicketCategories",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "TicketCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "PriorityCoefficient",
                value: 1.0);

            migrationBuilder.UpdateData(
                table: "TicketCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "PriorityCoefficient",
                value: 3.0);

            migrationBuilder.UpdateData(
                table: "TicketCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "PriorityCoefficient",
                value: 5.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriorityCoefficient",
                table: "TicketCategories");
        }
    }
}
