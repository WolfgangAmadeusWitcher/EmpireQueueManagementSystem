using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.QueueService.Api.Migrations
{
    public partial class AddedActiveWaitersCountToQueuesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveWaitersCount",
                table: "EmpireQueues",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveWaitersCount",
                table: "EmpireQueues");
        }
    }
}
