using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class RecordImageNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "record_image_id_fkey",
                table: "record");

            migrationBuilder.AlterColumn<int>(
                name: "image_id",
                table: "record",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "record_image_id_fkey",
                table: "record",
                column: "image_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "record_image_id_fkey",
                table: "record");

            migrationBuilder.AlterColumn<int>(
                name: "image_id",
                table: "record",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "record_image_id_fkey",
                table: "record",
                column: "image_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}