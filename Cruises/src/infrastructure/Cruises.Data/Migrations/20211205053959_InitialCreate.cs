using Microsoft.EntityFrameworkCore.Migrations;

namespace Cruises.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CruiseLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CruiseLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CruisePackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Hope = table.Column<string>(type: "TEXT", nullable: true),
                    MapLocation = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    Confirmation = table.Column<bool>(type: "INTEGER", nullable: false),
                    Currency = table.Column<int>(type: "INTEGER", nullable: false),
                    CruiseListId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CruisePackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CruisePackages_CruiseLists_CruiseListId",
                        column: x => x.CruiseListId,
                        principalTable: "CruiseLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CruisePackages_CruiseListId",
                table: "CruisePackages",
                column: "CruiseListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CruisePackages");

            migrationBuilder.DropTable(
                name: "CruiseLists");
        }
    }
}
