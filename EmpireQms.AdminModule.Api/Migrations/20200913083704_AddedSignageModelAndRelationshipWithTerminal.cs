using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.AdminModule.Api.Migrations
{
    public partial class AddedSignageModelAndRelationshipWithTerminal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Signages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TerminalSignages",
                columns: table => new
                {
                    TerminalId = table.Column<int>(nullable: false),
                    SignageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalSignages", x => new { x.TerminalId, x.SignageId });
                    table.ForeignKey(
                        name: "FK_TerminalSignages_Signages_SignageId",
                        column: x => x.SignageId,
                        principalTable: "Signages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerminalSignages_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TerminalSignages_SignageId",
                table: "TerminalSignages",
                column: "SignageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerminalSignages");

            migrationBuilder.DropTable(
                name: "Signages");
        }
    }
}
