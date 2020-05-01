using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class EditStyleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "style",
                columns: new[] { "id", "genre_id", "name" },
                values: new object[] { -3, -3, "Contemporary R&B" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -3);
        }
    }
}
