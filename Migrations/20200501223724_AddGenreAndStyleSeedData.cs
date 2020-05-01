using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddGenreAndStyleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "genre",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { -1, "Rock" },
                    { -2, "Electronic" },
                    { -3, "Soul/R&B" },
                    { -4, "Funk" },
                    { -5, "Country" },
                    { -6, "Latin" },
                    { -7, "Reggae" },
                    { -8, "Hip hop music" },
                    { -9, "Jazz" },
                    { -10, "Pop" },
                    { -11, "Classical" },
                    { -12, "Avant-garde" },
                    { -13, "Blues" }
                });

            migrationBuilder.InsertData(
                table: "style",
                columns: new[] { "id", "genre_id", "name" },
                values: new object[,]
                {
                    { -1, -2, "IDM" },
                    { -2, -2, "Ambient" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -2);
        }
    }
}
