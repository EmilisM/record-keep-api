using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace record_keep_api.Migrations
{
    public partial class AddStyleAndGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "style_id",
                table: "record",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "genre",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_genre", x => x.id); });

            migrationBuilder.CreateTable(
                name: "style",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_style", x => x.id); });

            migrationBuilder.CreateIndex(
                name: "IX_record_style_id",
                table: "record",
                column: "style_id");

            migrationBuilder.CreateIndex(
                name: "genre_name_key",
                table: "genre",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "style_name_key",
                table: "style",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "record_style_id_fkey",
                table: "record",
                column: "style_id",
                principalTable: "style",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "record_style_id_fkey",
                table: "record");

            migrationBuilder.DropTable(
                name: "genre");

            migrationBuilder.DropTable(
                name: "style");

            migrationBuilder.DropIndex(
                name: "IX_record_style_id",
                table: "record");

            migrationBuilder.DropColumn(
                name: "style_id",
                table: "record");
        }
    }
}