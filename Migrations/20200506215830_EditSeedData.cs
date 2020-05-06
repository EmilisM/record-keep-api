using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class EditSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -8,
                column: "name",
                value: "Hip hop");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -8,
                column: "name",
                value: "Hip hop music");
        }
    }
}
