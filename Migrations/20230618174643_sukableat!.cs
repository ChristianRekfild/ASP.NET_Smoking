using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP_Test.Migrations
{
    /// <inheritdoc />
    public partial class sukableat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OnlineURL",
                table: "Videos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Videos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Review",
                table: "Videos",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnlineURL",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "Review",
                table: "Videos");
        }
    }
}
