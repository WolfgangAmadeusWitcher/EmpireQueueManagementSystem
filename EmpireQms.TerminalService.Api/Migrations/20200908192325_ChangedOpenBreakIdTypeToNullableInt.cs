using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TerminalService.Api.Migrations
{
    public partial class ChangedOpenBreakIdTypeToNullableInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OpenBreakId",
                table: "Terminals",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OpenBreakId",
                table: "Terminals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
