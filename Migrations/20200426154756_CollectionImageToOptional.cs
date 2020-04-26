using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class CollectionImageToOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "collection_images_fkey",
                table: "collection");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "collection",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "collection_images_fkey",
                table: "collection",
                column: "ImageId",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "collection_images_fkey",
                table: "collection");

            migrationBuilder.AlterColumn<int>(
                name: "ImageId",
                table: "collection",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "collection_images_fkey",
                table: "collection",
                column: "ImageId",
                principalTable: "image",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
