using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.QueueService.Api.Migrations
{
    public partial class AddedServiceCompletedDateToTicketsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ServiceCompletedDate",
                table: "Tickets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceCompletedDate",
                table: "Tickets");
        }
    }
}
