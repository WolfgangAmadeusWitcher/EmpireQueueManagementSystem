using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TicketDispenser.Api.Migrations
{
    public partial class AddedDispensingQueuesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DispensingQueues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TicketCategoryId = table.Column<int>(nullable: false),
                    LastIssuedTicketNumber = table.Column<int>(nullable: false),
                    LastEnqueuedTicketNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispensingQueues");
        }
    }
}
