using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class UserActivityActionValueConversionSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user_activity_action",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { -1, "CollectionCreate" },
                    { -2, "CollectionUpdate" },
                    { -3, "CollectionDelete" },
                    { -4, "RecordCreate" },
                    { -5, "RecordDelete" },
                    { -6, "RecordUpdate" },
                    { -7, "ImageCreate" },
                    { -8, "ImageUpdate" },
                    { -9, "UserUpdate" },
                    { -10, "CollectionDeleteWithMove" },
                    { -11, "PasswordChange" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_activity_action",
                keyColumn: "id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "user_activity_action",
                keyColumn: "id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "user_activity_action",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "user_activity_action",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "user_activity_action",
                keyColumn: "id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "user_activity_action",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "user_activity_action",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "user_activity_action",
                keyColumn: "id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "user_activity_action",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "user_activity_action",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "user_activity_action",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
