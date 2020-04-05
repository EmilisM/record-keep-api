using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class AddUserDataDisplayNameAndEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "user_data_user_name_key",
                table: "user_data");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "user_data");

            migrationBuilder.AddColumn<string>(
                name: "display_name",
                table: "user_data",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "user_data",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "user_data_email_key",
                table: "user_data",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "user_data_email_key",
                table: "user_data");

            migrationBuilder.DropColumn(
                name: "display_name",
                table: "user_data");

            migrationBuilder.DropColumn(
                name: "email",
                table: "user_data");

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "user_data",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "user_data_user_name_key",
                table: "user_data",
                column: "user_name",
                unique: true);
        }
    }
}
