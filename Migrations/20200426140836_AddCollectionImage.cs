using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddCollectionImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "profile_image_profile_images_id_fkey",
                table: "user_data");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "collection",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_collection_ImageId",
                table: "collection",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "collection_images_fkey",
                table: "collection",
                column: "ImageId",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "profile_image_profiles_id_fkey",
                table: "user_data",
                column: "profile_image_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "collection_images_fkey",
                table: "collection");

            migrationBuilder.DropForeignKey(
                name: "profile_image_profiles_id_fkey",
                table: "user_data");

            migrationBuilder.DropIndex(
                name: "IX_collection_ImageId",
                table: "collection");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "collection");

            migrationBuilder.AddForeignKey(
                name: "profile_image_profile_images_id_fkey",
                table: "user_data",
                column: "profile_image_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}