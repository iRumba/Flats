using Microsoft.EntityFrameworkCore.Migrations;

namespace Flats.Gui.Migrations
{
    public partial class AddFlatFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Flats",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Flats",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Flats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Flats",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Flats");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Flats");
        }
    }
}
