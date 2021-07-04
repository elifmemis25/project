using Microsoft.EntityFrameworkCore.Migrations;

namespace Book.Migrations
{
    public partial class EkleAlbumSarkiTablosuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Album",
                table: "Song",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Album",
                table: "Song");
        }
    }
}
