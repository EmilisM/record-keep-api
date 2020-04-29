using Microsoft.EntityFrameworkCore.Migrations;

namespace record_keep_api.Migrations
{
    public partial class UserDataDisplayNameToText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "user_data",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "user_data",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}