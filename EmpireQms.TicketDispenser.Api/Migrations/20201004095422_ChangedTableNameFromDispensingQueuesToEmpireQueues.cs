using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TicketDispenser.Api.Migrations
{
    public partial class ChangedTableNameFromDispensingQueuesToEmpireQueues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispensingQueues");

            migrationBuilder.CreateTable(
                name: "EmpireQueues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TicketCategoryId = table.Column<int>(nullable: false),
                    LastIssuedTicketNumber = table.Column<int>(nullable: true),
                    LastEnqueuedTicketNumber = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpireQueues");

            migrationBuilder.CreateTable(
                name: "DispensingQueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LastEnqueuedTicketNumber = table.Column<int>(type: "int", nullable: true),
                    LastIssuedTicketNumber = table.Column<int>(type: "int", nullable: true),
                    TicketCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }
    }
}
