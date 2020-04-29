using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace record_keep_api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "image",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    url = table.Column<string>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_image", x => x.id); });

            migrationBuilder.CreateTable(
                name: "record_type",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_record_type", x => x.id); });

            migrationBuilder.CreateTable(
                name: "user_data",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(maxLength: 50, nullable: false),
                    password_hash = table.Column<string>(nullable: false),
                    password_salt = table.Column<string>(nullable: false),
                    creation_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_user_data", x => x.id); });

            migrationBuilder.CreateTable(
                name: "record",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    artist = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    creation_date = table.Column<DateTime>(type: "date", nullable: false),
                    record_type_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record", x => x.id);
                    table.ForeignKey(
                        name: "record_record_type_id_fkey",
                        column: x => x.record_type_id,
                        principalTable: "record_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "collection",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    creation_date = table.Column<DateTime>(type: "date", nullable: false),
                    owner_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collection", x => x.id);
                    table.ForeignKey(
                        name: "collection_owner_id_fkey",
                        column: x => x.owner_id,
                        principalTable: "user_data",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "collection_records",
                columns: table => new
                {
                    collection_id = table.Column<int>(nullable: false),
                    record_id = table.Column<int>(nullable: false)
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
                name: "IX_collection_owner_id",
                table: "collection",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "IX_collection_records_record_id",
                table: "collection_records",
                column: "record_id");

            migrationBuilder.CreateIndex(
                name: "IX_record_record_type_id",
                table: "record",
                column: "record_type_id");

            migrationBuilder.CreateIndex(
                name: "user_data_user_name_key",
                table: "user_data",
                column: "user_name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collection_records");

            migrationBuilder.DropTable(
                name: "image");

            migrationBuilder.DropTable(
                name: "record");

            migrationBuilder.DropTable(
                name: "collection");

            migrationBuilder.DropTable(
                name: "record_type");

            migrationBuilder.DropTable(
                name: "user_data");
        }
    }
}