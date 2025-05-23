using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entryflowBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class AddFinalizedConstraintToAdminModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "CardUid",
                table: "Employees",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Admins",
                type: "character varying(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Admins",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Admins",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Admins",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "CardUid",
                table: "Employees",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Admins",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(320)",
                oldMaxLength: 320);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Admins",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Admins",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
