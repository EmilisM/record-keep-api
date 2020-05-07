using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddOnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "user_activity_collection_id_fkey",
                table: "user_activity");

            migrationBuilder.DropForeignKey(
                name: "user_activity_record_id_fkey",
                table: "user_activity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "time_stamp",
                table: "user_activity",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now() at time zone 'utc'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "user_activity_collection_id_fkey",
                table: "user_activity");

            migrationBuilder.DropForeignKey(
                name: "user_activity_record_id_fkey",
                table: "user_activity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "time_stamp",
                table: "user_activity",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now() at time zone 'utc'");

            migrationBuilder.AddForeignKey(
                name: "user_activity_collection_id_fkey",
                table: "user_activity",
                column: "collection_id",
                principalTable: "collection",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "user_activity_record_id_fkey",
                table: "user_activity",
                column: "record_id",
                principalTable: "record",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
