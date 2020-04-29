using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class RemoveCollectionRecordsAddCollectionToRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collection_records");

            migrationBuilder.AddColumn<int>(
                name: "collection_id",
                table: "record",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "owner_id",
                table: "record",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_record_collection_id",
                table: "record",
                column: "collection_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_owner_id",
                table: "record",
                column: "owner_id");

            migrationBuilder.AddForeignKey(
                name: "record_collection_id_fkey",
                table: "record",
                column: "collection_id",
                principalTable: "collection",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "record_owner_id_fkey",
                table: "record",
                column: "owner_id",
                principalTable: "user_data",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "record_collection_id_fkey",
                table: "record");

            migrationBuilder.DropForeignKey(
                name: "record_owner_id_fkey",
                table: "record");

            migrationBuilder.DropIndex(
                name: "IX_record_collection_id",
                table: "record");

            migrationBuilder.DropIndex(
                name: "IX_record_owner_id",
                table: "record");

            migrationBuilder.DropColumn(
                name: "collection_id",
                table: "record");

            migrationBuilder.DropColumn(
                name: "owner_id",
                table: "record");

            migrationBuilder.CreateTable(
                name: "collection_records",
                columns: table => new
                {
                    collection_id = table.Column<int>(type: "integer", nullable: false),
                    record_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("collection_records_pkey", x => new {x.collection_id, x.record_id});
                    table.ForeignKey(
                        name: "collection_records_collection_id_fkey",
                        column: x => x.collection_id,
                        principalTable: "collection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "collection_records_record_id_fkey",
                        column: x => x.record_id,
                        principalTable: "collection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_collection_records_record_id",
                table: "collection_records",
                column: "record_id");
        }
    }
}