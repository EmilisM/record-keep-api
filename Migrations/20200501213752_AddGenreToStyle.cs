using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddGenreToStyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "genre_id",
                table: "style",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_style_genre_id",
                table: "style",
                column: "genre_id");

            migrationBuilder.AddForeignKey(
                name: "style_genre_id_fkey",
                table: "style",
                column: "genre_id",
                principalTable: "genre",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "style_genre_id_fkey",
                table: "style");

            migrationBuilder.DropIndex(
                name: "IX_style_genre_id",
                table: "style");

            migrationBuilder.DropColumn(
                name: "genre_id",
                table: "style");
        }
    }
}