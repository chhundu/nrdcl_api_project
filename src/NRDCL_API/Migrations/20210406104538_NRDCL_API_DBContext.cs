using Microsoft.EntityFrameworkCore.Migrations;

namespace NRDCL_API.Migrations
{
    public partial class NRDCL_API_DBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_Table",
                columns: table => new
                {
                    CitizenshipID = table.Column<string>(type: "text", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    TelephoneNumber = table.Column<string>(type: "text", nullable: false),
                    EmailId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Table", x => x.CitizenshipID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_Table");
        }
    }
}
