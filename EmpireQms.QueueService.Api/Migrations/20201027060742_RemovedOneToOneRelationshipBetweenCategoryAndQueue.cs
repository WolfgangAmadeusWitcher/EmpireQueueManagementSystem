using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.QueueService.Api.Migrations
{
    public partial class RemovedOneToOneRelationshipBetweenCategoryAndQueue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpireQueues_TicketCategories_TicketCategoryId",
                table: "EmpireQueues");

            migrationBuilder.DropIndex(
                name: "IX_EmpireQueues_TicketCategoryId",
                table: "EmpireQueues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_EmpireQueues_TicketCategoryId",
                table: "EmpireQueues",
                column: "TicketCategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmpireQueues_TicketCategories_TicketCategoryId",
                table: "EmpireQueues",
                column: "TicketCategoryId",
                principalTable: "TicketCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
