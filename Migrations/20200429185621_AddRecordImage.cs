using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddRecordImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "image_id",
                table: "record",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_record_image_id",
                table: "record",
                column: "image_id");

            migrationBuilder.AddForeignKey(
                name: "record_image_id_fkey",
                table: "record",
                column: "image_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "record_image_id_fkey",
                table: "record");

            migrationBuilder.DropIndex(
                name: "IX_record_image_id",
                table: "record");

            migrationBuilder.DropColumn(
                name: "image_id",
                table: "record");
        }
    }
}