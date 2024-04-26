using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    public partial class RemoveBookId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Books_BookId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BookId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BookId",
                table: "Users",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Books_BookId",
                table: "Users",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
