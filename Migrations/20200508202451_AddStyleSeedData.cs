using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddStyleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "genre",
                keyColumn: "id",
                keyValue: -12);

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -11,
                column: "name",
                value: "Blues");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -10,
                column: "name",
                value: "Avant-garde");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -9,
                column: "name",
                value: "Classical");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -8,
                column: "name",
                value: "Pop");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -7,
                column: "name",
                value: "Jazz");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -6,
                column: "name",
                value: "Hip hop");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -5,
                column: "name",
                value: "Latin");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -4,
                column: "name",
                value: "Country");

            migrationBuilder.UpdateData(
                table: "style",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "genre_id", "name" },
                values: new object[] { -2, "Downtempo" });

            migrationBuilder.InsertData(
                table: "style",
                columns: new[] { "id", "genre_id", "name" },
                values: new object[,]
                {
                    { -62, -8, "Indie pop" },
                    { -61, -8, "Psychedelic pop" },
                    { -60, -8, "Pop rock" },
                    { -59, -8, "Europop" },
                    { -58, -8, "Baroque pop" },
                    { -57, -7, "Chamber jazz" },
                    { -54, -7, "Swing" },
                    { -55, -7, "Jazz fusion" },
                    { -63, -8, "K-pop" },
                    { -53, -7, "Free jazz" },
                    { -52, -7, "Avant-garde jazz" },
                    { -51, -6, "West Coast hip hop" },
                    { -50, -6, "Trap" },
                    { -49, -6, "Mumble rap" },
                    { -56, -7, "Smooth jazz" },
                    { -64, -8, "Synthpop" },
                    { -67, -9, "Modern" },
                    { -66, -9, "Early" },
                    { -81, -11, "Electric blues" },
                    { -80, -11, "Chicago blues" },
                    { -79, -11, "St. Louis blues" },
                    { -78, -11, "Soul blues" },
                    { -77, -11, "Gospel blues" },
                    { -76, -11, "British blues" },
                    { -65, -9, "Ancient" },
                    { -75, -11, "Texas blues" },
                    { -73, -11, "Blues rock" },
                    { -72, -10, "Musique concrète" },
                    { -71, -10, "Noise" },
                    { -70, -10, "Experimental" },
                    { -69, -9, "Contemporary" },
                    { -48, -6, "Grime" },
                    { -74, -11, "Detroit blues" },
                    { -68, -9, "Postmodern" },
                    { -47, -6, "Hardcore hip hop" },
                    { -45, -6, "G-funk" },
                    { -21, -3, "Contemporary R&B" },
                    { -20, -1, "Progressive rock" },
                    { -19, -1, "Psychedelic rock" },
                    { -18, -1, "New wave" },
                    { -17, -1, "Rap rock" },
                    { -16, -1, "Punk rock" },
                    { -15, -1, "Heavy metal" },
                    { -14, -1, "Experimental rock" },
                    { -13, -1, "Alternative rock" },
                    { -12, -2, "UK garage" },
                    { -11, -2, "Techno" },
                    { -10, -2, "Jungle" },
                    { -9, -2, "Industrial" },
                    { -8, -2, "House" },
                    { -7, -2, "Electronica" },
                    { -6, -2, "Electroacoustic" },
                    { -5, -2, "Dub" },
                    { -22, -3, "Disco" },
                    { -23, -3, "Funk" },
                    { -24, -3, "Soul" },
                    { -25, -3, "Alternative R&B" },
                    { -44, -6, "Conscious hip hop" },
                    { -43, -6, "Cloud rap" },
                    { -42, -6, "British hip hop" },
                    { -41, -6, "Experimental hip hop" },
                    { -40, -6, "Alternative hip hop" },
                    { -39, -5, "Tropical" },
                    { -38, -5, "Traditional" },
                    { -37, -5, "Regional Mexican" },
                    { -46, -6, "Gangsta rap" },
                    { -36, -5, "Reggaeton" },
                    { -34, -5, "Latin jazz" },
                    { -33, -5, "Brazilian" },
                    { -32, -4, "Texas country" },
                    { -31, -4, "Instrumental country" },
                    { -30, -4, "Country pop" },
                    { -29, -4, "Country rock" },
                    { -28, -4, "Country blues" },
                    { -27, -4, "Classic country" },
                    { -35, -5, "Latin rock" },
                    { -4, -2, "Drum and bass" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -81);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -80);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -79);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -78);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -77);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -76);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -75);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -74);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -73);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -72);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -71);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -70);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -69);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -68);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -67);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -66);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -65);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -64);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -63);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -62);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -61);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -60);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -59);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -58);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -57);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -56);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -55);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -54);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -53);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -52);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -51);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -50);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -49);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -48);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -47);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -46);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -45);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -44);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -43);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -42);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -41);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -40);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -39);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -38);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -37);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -36);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -35);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -34);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -33);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -32);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -31);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -30);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -29);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -28);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -27);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -25);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -24);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -23);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -22);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -21);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -20);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -19);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -18);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -17);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -16);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "style",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -11,
                column: "name",
                value: "Classical");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -10,
                column: "name",
                value: "Pop");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -9,
                column: "name",
                value: "Jazz");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -8,
                column: "name",
                value: "Hip hop");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -7,
                column: "name",
                value: "Reggae");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -6,
                column: "name",
                value: "Latin");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -5,
                column: "name",
                value: "Country");

            migrationBuilder.UpdateData(
                table: "genre",
                keyColumn: "id",
                keyValue: -4,
                column: "name",
                value: "Funk");

            migrationBuilder.InsertData(
                table: "genre",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { -12, "Avant-garde" },
                    { -13, "Blues" }
                });

            migrationBuilder.UpdateData(
                table: "style",
                keyColumn: "id",
                keyValue: -3,
                columns: new[] { "genre_id", "name" },
                values: new object[] { -3, "Contemporary R&B" });
        }
    }
}
