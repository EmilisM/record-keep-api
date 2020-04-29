using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class UpdateRecordTypeSeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "record_type",
                columns: new[] {"id", "name"},
                values: new object[] {-4, "Tape"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "record_type",
                keyColumn: "id",
                keyValue: -4);
        }
    }
}