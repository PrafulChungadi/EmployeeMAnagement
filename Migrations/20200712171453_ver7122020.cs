using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class ver7122020 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblEmployee",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tblAddress",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(nullable: false),
                    employeeid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAddress", x => x.id);
                    table.ForeignKey(
                        name: "FK_tblAddress_tblEmployee_employeeid",
                        column: x => x.employeeid,
                        principalTable: "tblEmployee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAddress_employeeid",
                table: "tblAddress",
                column: "employeeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAddress");

            migrationBuilder.DropTable(
                name: "tblEmployee");
        }
    }
}
