using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TicketDispenser.Api.Migrations
{
    public partial class AddedPrimaryKeyToEmpireQueueTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpireQueues",
                table: "EmpireQueues",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpireQueues",
                table: "EmpireQueues");
        }
    }
}
