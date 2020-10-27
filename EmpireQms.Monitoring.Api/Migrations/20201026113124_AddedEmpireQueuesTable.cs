using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.Monitoring.Api.Migrations
{
    public partial class AddedEmpireQueuesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmpireQueues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TicketCategoryId = table.Column<int>(nullable: false),
                    QueueWeight = table.Column<double>(nullable: false),
                    ActiveWaitersCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpireQueues", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpireQueues");
        }
    }
}
