using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entryflowBackend.API.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToValidators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiKey",
                table: "Validators");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Validators",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecretKey",
                table: "Validators",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Validators");

            migrationBuilder.DropColumn(
                name: "SecretKey",
                table: "Validators");

            migrationBuilder.AddColumn<string>(
                name: "ApiKey",
                table: "Validators",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
