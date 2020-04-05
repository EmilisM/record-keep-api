using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddRecordTypeSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "record_type",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { -1, "LP" },
                    { -2, "CD" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "record_type",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "record_type",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
