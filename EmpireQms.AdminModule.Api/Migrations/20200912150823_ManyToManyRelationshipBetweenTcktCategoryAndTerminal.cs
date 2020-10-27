using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.AdminModule.Api.Migrations
{
    public partial class ManyToManyRelationshipBetweenTcktCategoryAndTerminal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TerminalCategories",
                columns: table => new
                {
                    TicketCategoryId = table.Column<int>(nullable: false),
                    TerminalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalCategories", x => new { x.TerminalId, x.TicketCategoryId });
                    table.ForeignKey(
                        name: "FK_TerminalCategories_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TerminalCategories_TicketCategories_TicketCategoryId",
                        column: x => x.TicketCategoryId,
                        principalTable: "TicketCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TerminalCategories_TicketCategoryId",
                table: "TerminalCategories",
                column: "TicketCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TerminalCategories");
        }
    }
}
