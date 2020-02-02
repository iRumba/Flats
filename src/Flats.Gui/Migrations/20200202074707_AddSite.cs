using Microsoft.EntityFrameworkCore.Migrations;

namespace Flats.Gui.Migrations
{
    public partial class AddSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, defaultValueSql: "CONVERT(varchar(255), NEWID())"),
                    Name = table.Column<string>(nullable: true),
                    UrlTemplate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
