using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace record_keep_api.Migrations
{
    public partial class AddUserActivityAndUserActivityAction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_activity_action",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_activity_action", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_activity",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    time_stamp = table.Column<DateTime>(type: "date", nullable: false),
                    owner_id = table.Column<int>(nullable: false),
                    action_id = table.Column<int>(nullable: false),
                    collection_id = table.Column<int>(nullable: true),
                    record_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_activity", x => x.id);
                    table.ForeignKey(
                        name: "user_activity_action_id_fkey",
                        column: x => x.action_id,
                        principalTable: "user_activity_action",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_activity_collection_id_fkey",
                        column: x => x.collection_id,
                        principalTable: "collection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_activity_owner_id_fkey",
                        column: x => x.owner_id,
                        principalTable: "user_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "user_activity_record_id_fkey",
                        column: x => x.record_id,
                        principalTable: "record",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_activity_action_id",
                table: "user_activity",
                column: "action_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_activity_collection_id",
                table: "user_activity",
                column: "collection_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_activity_owner_id",
                table: "user_activity",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_activity_record_id",
                table: "user_activity",
                column: "record_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_activity");

            migrationBuilder.DropTable(
                name: "user_activity_action");
        }
    }
}
