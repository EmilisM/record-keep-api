using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class RenameImageUrlToData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url",
                table: "image");

            migrationBuilder.AddColumn<string>(
                name: "data",
                table: "image",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "data",
                table: "image");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "image",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}