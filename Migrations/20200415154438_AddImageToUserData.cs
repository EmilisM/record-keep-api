using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddImageToUserData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "image_id",
                table: "user_data",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_data_image_id",
                table: "user_data",
                column: "image_id");

            migrationBuilder.AddForeignKey(
                name: "user_data_image_id_fkey",
                table: "user_data",
                column: "image_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "user_data_image_id_fkey",
                table: "user_data");

            migrationBuilder.DropIndex(
                name: "IX_user_data_image_id",
                table: "user_data");

            migrationBuilder.DropColumn(
                name: "image_id",
                table: "user_data");
        }
    }
}