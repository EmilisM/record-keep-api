using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class UserActivityDeleteClientSetNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "user_activity_collection_id_fkey",
                table: "user_activity");

            migrationBuilder.DropForeignKey(
                name: "user_activity_record_id_fkey",
                table: "user_activity");

            migrationBuilder.AddForeignKey(
                name: "user_activity_collection_id_fkey",
                table: "user_activity",
                column: "collection_id",
                principalTable: "collection",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "user_activity_record_id_fkey",
                table: "user_activity",
                column: "record_id",
                principalTable: "record",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "user_activity_collection_id_fkey",
                table: "user_activity");

            migrationBuilder.DropForeignKey(
                name: "user_activity_record_id_fkey",
                table: "user_activity");

            migrationBuilder.AddForeignKey(
                name: "user_activity_collection_id_fkey",
                table: "user_activity",
                column: "collection_id",
                principalTable: "collection",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "user_activity_record_id_fkey",
                table: "user_activity",
                column: "record_id",
                principalTable: "record",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
