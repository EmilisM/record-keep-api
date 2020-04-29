using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddImageCreatorAddManyRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_data_image_image_id",
                table: "user_data");

            migrationBuilder.DropIndex(
                name: "IX_user_data_image_id",
                table: "user_data");

            migrationBuilder.DropColumn(
                name: "image_id",
                table: "user_data");

            migrationBuilder.AddColumn<int>(
                name: "profile_image_id",
                table: "user_data",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "creator_id",
                table: "image",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_user_data_profile_image_id",
                table: "user_data",
                column: "profile_image_id");

            migrationBuilder.CreateIndex(
                name: "IX_image_creator_id",
                table: "image",
                column: "creator_id");

            migrationBuilder.AddForeignKey(
                name: "image_created_image_id_fkey",
                table: "image",
                column: "creator_id",
                principalTable: "user_data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "profile_image_profile_images_id_fkey",
                table: "user_data",
                column: "profile_image_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "image_created_image_id_fkey",
                table: "image");

            migrationBuilder.DropForeignKey(
                name: "profile_image_profile_images_id_fkey",
                table: "user_data");

            migrationBuilder.DropIndex(
                name: "IX_user_data_profile_image_id",
                table: "user_data");

            migrationBuilder.DropIndex(
                name: "IX_image_creator_id",
                table: "image");

            migrationBuilder.DropColumn(
                name: "profile_image_id",
                table: "user_data");

            migrationBuilder.DropColumn(
                name: "creator_id",
                table: "image");

            migrationBuilder.AddColumn<int>(
                name: "image_id",
                table: "user_data",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_data_image_id",
                table: "user_data",
                column: "image_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_data_image_image_id",
                table: "user_data",
                column: "image_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}