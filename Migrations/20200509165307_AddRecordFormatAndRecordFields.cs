using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace record_keep_api.Migrations
{
    public partial class AddRecordFormatAndRecordFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "record_styles_record_id_fkey",
                table: "record_styles");

            migrationBuilder.DropForeignKey(
                name: "record_styles_style_id_fkey",
                table: "record_styles");

            migrationBuilder.DeleteData(
                table: "record_type",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.AddColumn<decimal>(
                name: "rating",
                table: "record",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "record_format_id",
                table: "record",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "record_length",
                table: "record",
                type: "date",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "record_format",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record_format", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "record_format",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { -1, "LP" },
                    { -2, "CD" },
                    { -3, "Vinyl" },
                    { -4, "Tape" },
                    { -5, "7\"" },
                    { -6, "12\"" },
                    { -7, "File" }
                });

            migrationBuilder.UpdateData(
                table: "record_type",
                keyColumn: "id",
                keyValue: -3,
                column: "name",
                value: "Compilation");

            migrationBuilder.UpdateData(
                table: "record_type",
                keyColumn: "id",
                keyValue: -2,
                column: "name",
                value: "Single");

            migrationBuilder.UpdateData(
                table: "record_type",
                keyColumn: "id",
                keyValue: -1,
                column: "name",
                value: "Album");

            migrationBuilder.CreateIndex(
                name: "IX_record_record_format_id",
                table: "record",
                column: "record_format_id");

            migrationBuilder.CreateIndex(
                name: "record_format_name_key",
                table: "record_format",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "record_record_format_id_fkey",
                table: "record",
                column: "record_format_id",
                principalTable: "record_format",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "record_style_record_id_fkey",
                table: "record_styles",
                column: "record_id",
                principalTable: "record",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "record_style_style_id_fkey",
                table: "record_styles",
                column: "style_id",
                principalTable: "style",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "record_record_format_id_fkey",
                table: "record");

            migrationBuilder.DropForeignKey(
                name: "record_style_record_id_fkey",
                table: "record_styles");

            migrationBuilder.DropForeignKey(
                name: "record_style_style_id_fkey",
                table: "record_styles");

            migrationBuilder.DropTable(
                name: "record_format");

            migrationBuilder.DropIndex(
                name: "IX_record_record_format_id",
                table: "record");

            migrationBuilder.DropColumn(
                name: "rating",
                table: "record");

            migrationBuilder.DropColumn(
                name: "record_format_id",
                table: "record");

            migrationBuilder.DropColumn(
                name: "record_length",
                table: "record");

            migrationBuilder.UpdateData(
                table: "record_type",
                keyColumn: "id",
                keyValue: -3,
                column: "name",
                value: "Vinyl");

            migrationBuilder.UpdateData(
                table: "record_type",
                keyColumn: "id",
                keyValue: -2,
                column: "name",
                value: "CD");

            migrationBuilder.UpdateData(
                table: "record_type",
                keyColumn: "id",
                keyValue: -1,
                column: "name",
                value: "LP");

            migrationBuilder.InsertData(
                table: "record_type",
                columns: new[] { "id", "name" },
                values: new object[] { -4, "Tape" });

            migrationBuilder.AddForeignKey(
                name: "record_styles_record_id_fkey",
                table: "record_styles",
                column: "record_id",
                principalTable: "record",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "record_styles_style_id_fkey",
                table: "record_styles",
                column: "style_id",
                principalTable: "style",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
