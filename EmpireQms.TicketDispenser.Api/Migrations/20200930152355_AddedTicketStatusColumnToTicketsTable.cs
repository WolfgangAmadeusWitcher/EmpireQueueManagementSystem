using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.TicketDispenser.Api.Migrations
{
    public partial class AddedTicketStatusColumnToTicketsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "TicketStatus",
                table: "Tickets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketStatus",
                table: "Tickets");

            migrationBuilder.InsertData(
                table: "TicketCategories",
                columns: new[] { "Id", "Description", "FirstTicketNumber", "LastTicketNumber", "Name" },
                values: new object[] { 1, "Gişe işlemleri yapmak", 100, 200, "Gişe İşlemleri" });

            migrationBuilder.InsertData(
                table: "TicketCategories",
                columns: new[] { "Id", "Description", "FirstTicketNumber", "LastTicketNumber", "Name" },
                values: new object[] { 2, "Bireysel Bankacılık hizmetlerimizden faydalanmak", 300, 450, "Bireysel Hizmetler" });

            migrationBuilder.InsertData(
                table: "TicketCategories",
                columns: new[] { "Id", "Description", "FirstTicketNumber", "LastTicketNumber", "Name" },
                values: new object[] { 3, "Kurumsal Bankacılık hizmetlerimizden faydalanmak", 450, 750, "Ticari İşlemler" });
        }
    }
}
