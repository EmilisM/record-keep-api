using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddDescriptionToRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "record",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "record");
        }
    }
}