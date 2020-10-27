using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TicketDispenser.Api.Migrations
{
    public partial class MadeTicketNumberColumnsInDispensingQueueNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LastIssuedTicketNumber",
                table: "DispensingQueues",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LastEnqueuedTicketNumber",
                table: "DispensingQueues",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LastIssuedTicketNumber",
                table: "DispensingQueues",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LastEnqueuedTicketNumber",
                table: "DispensingQueues",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
