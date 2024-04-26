using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    public partial class AddImageCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Books",
                newName: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Books",
                newName: "ImageURL");
        }
    }
}
