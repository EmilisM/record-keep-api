using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class RemoveUserDataCollectionsAndImageUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "collection_owner_id_fkey",
                table: "collection");

            migrationBuilder.DropForeignKey(
                name: "user_data_image_id_fkey",
                table: "user_data");

            migrationBuilder.AddForeignKey(
                name: "FK_collection_user_data_owner_id",
                table: "collection",
                column: "owner_id",
                principalTable: "user_data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_data_image_image_id",
                table: "user_data",
                column: "image_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_collection_user_data_owner_id",
                table: "collection");

            migrationBuilder.DropForeignKey(
                name: "FK_user_data_image_image_id",
                table: "user_data");

            migrationBuilder.AddForeignKey(
                name: "collection_owner_id_fkey",
                table: "collection",
                column: "owner_id",
                principalTable: "user_data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "user_data_image_id_fkey",
                table: "user_data",
                column: "image_id",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}