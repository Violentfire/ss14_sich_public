using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Content.Server.Database.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class AddSponsorRankColor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sponsor_level",
                table: "sich_sponsor");

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "sponsor_rank",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "color",
                table: "sponsor_rank");

            migrationBuilder.AddColumn<string>(
                name: "sponsor_level",
                table: "sich_sponsor",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
