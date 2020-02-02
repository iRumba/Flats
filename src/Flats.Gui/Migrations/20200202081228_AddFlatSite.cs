using Microsoft.EntityFrameworkCore.Migrations;

namespace Flats.Gui.Migrations
{
    public partial class AddFlatSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlatSites",
                columns: table => new
                {
                    FlatId = table.Column<string>(nullable: false),
                    SiteId = table.Column<string>(nullable: false),
                    ForeignKey = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlatSites", x => new { x.FlatId, x.SiteId });
                    table.ForeignKey(
                        name: "FK_FlatSites_Flats_FlatId",
                        column: x => x.FlatId,
                        principalTable: "Flats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlatSites_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlatSites_SiteId",
                table: "FlatSites",
                column: "SiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlatSites");
        }
    }
}
