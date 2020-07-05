using Microsoft.EntityFrameworkCore.Migrations;

namespace EFSimpleExample.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZoneStates",
                columns: table => new
                {
                    ZoneKey = table.Column<string>(nullable: false),
                    NodeId_NodeId = table.Column<short>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZoneStates", x => x.ZoneKey);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZoneStates");
        }
    }
}
