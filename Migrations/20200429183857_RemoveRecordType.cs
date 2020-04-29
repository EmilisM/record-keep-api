using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace record_keep_api.Migrations
{
    public partial class RemoveRecordType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "record_record_type_id_fkey",
                table: "record");

            migrationBuilder.DropTable(
                name: "record_type");

            migrationBuilder.DropIndex(
                name: "IX_record_record_type_id",
                table: "record");

            migrationBuilder.DropColumn(
                name: "record_type_id",
                table: "record");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "record_type_id",
                table: "record",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "record_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_record_type", x => x.id); });

            migrationBuilder.InsertData(
                table: "record_type",
                columns: new[] {"id", "name"},
                values: new object[,]
                {
                    {-1, "LP"},
                    {-2, "CD"},
                    {-3, "Vinyl"},
                    {-4, "Tape"}
                });

            migrationBuilder.CreateIndex(
                name: "IX_record_record_type_id",
                table: "record",
                column: "record_type_id");

            migrationBuilder.AddForeignKey(
                name: "record_record_type_id_fkey",
                table: "record",
                column: "record_type_id",
                principalTable: "record_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}