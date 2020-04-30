using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class ReconfigureRecordTypeAddImageToRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "record_type",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "image_id",
                table: "record",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "record_type_name_key",
                table: "record_type",
                column: "name",
                unique: true);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "record_image_id_fkey",
                table: "record");

            migrationBuilder.DropIndex(
                name: "record_type_name_key",
                table: "record_type");

            migrationBuilder.DropIndex(
                name: "IX_record_image_id",
                table: "record");

            migrationBuilder.DropColumn(
                name: "image_id",
                table: "record");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "record_type",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}