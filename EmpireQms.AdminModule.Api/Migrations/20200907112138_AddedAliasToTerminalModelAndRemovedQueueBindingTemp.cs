using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.AdminModule.Api.Migrations
{
    public partial class AddedAliasToTerminalModelAndRemovedQueueBindingTemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QueueId",
                table: "Terminals");

            migrationBuilder.AddColumn<string>(
                name: "Alias",
                table: "Terminals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alias",
                table: "Terminals");

            migrationBuilder.AddColumn<int>(
                name: "QueueId",
                table: "Terminals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
