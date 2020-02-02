using Microsoft.EntityFrameworkCore.Migrations;

namespace Flats.Gui.Migrations
{
    public partial class AddFlatId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false, defaultValueSql: "CONVERT(varchar(255), NEWID())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flats");
        }
    }
}
