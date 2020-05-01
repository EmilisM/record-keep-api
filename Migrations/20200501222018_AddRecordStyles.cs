using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddRecordStyles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "record_style_id_fkey",
                table: "record");

            migrationBuilder.DropIndex(
                name: "IX_record_style_id",
                table: "record");

            migrationBuilder.DropColumn(
                name: "style_id",
                table: "record");

            migrationBuilder.CreateTable(
                name: "record_styles",
                columns: table => new
                {
                    record_id = table.Column<int>(nullable: false),
                    style_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_styles", x => new { x.record_id, x.style_id });
                    table.ForeignKey(
                        name: "record_styles_record_id_fkey",
                        column: x => x.record_id,
                        principalTable: "record",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "record_styles_style_id_fkey",
                        column: x => x.style_id,
                        principalTable: "style",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_record_styles_style_id",
                table: "record_styles",
                column: "style_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "record_styles");

            migrationBuilder.AddColumn<int>(
                name: "style_id",
                table: "record",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_record_style_id",
                table: "record",
                column: "style_id");

            migrationBuilder.AddForeignKey(
                name: "record_style_id_fkey",
                table: "record",
                column: "style_id",
                principalTable: "style",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
