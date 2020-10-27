using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TicketDispenser.Api.Migrations
{
    public partial class AddedTicketsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TicketCategories");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    TicketCategoryId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TicketCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
