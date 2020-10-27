using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpireQms.AdminModule.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FirstTicketNumber = table.Column<int>(nullable: false),
                    LastTicketNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCategories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TicketCategories",
                columns: new[] { "Id", "Description", "FirstTicketNumber", "IsDeleted", "LastTicketNumber", "Name" },
                values: new object[] { 1, "Gişe işlemleri yapmak", 100, false, 200, "Gişe İşlemleri" });

            migrationBuilder.InsertData(
                table: "TicketCategories",
                columns: new[] { "Id", "Description", "FirstTicketNumber", "IsDeleted", "LastTicketNumber", "Name" },
                values: new object[] { 2, "Bireysel Bankacılık hizmetlerimizden faydalanmak", 300, false, 450, "Bireysel Hizmetler" });

            migrationBuilder.InsertData(
                table: "TicketCategories",
                columns: new[] { "Id", "Description", "FirstTicketNumber", "IsDeleted", "LastTicketNumber", "Name" },
                values: new object[] { 3, "Kurumsal Bankacılık hizmetlerimizden faydalanmak", 450, false, 750, "Ticari İşlemler" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketCategories");
        }
    }
}
