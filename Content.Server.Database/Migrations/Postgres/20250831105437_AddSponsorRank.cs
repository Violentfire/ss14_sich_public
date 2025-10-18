using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Content.Server.Database.Migrations.Postgres
{
    /// <inheritdoc />
    public partial class AddSponsorRank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "expiration",
                table: "sich_sponsor");

            migrationBuilder.AddColumn<int>(
                name: "sponsor_rank_id",
                table: "sich_sponsor",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "sponsor_rank",
                columns: table => new
                {
                    sponsor_rank_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sponsor_rank", x => x.sponsor_rank_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sich_sponsor_sponsor_rank_id",
                table: "sich_sponsor",
                column: "sponsor_rank_id");

            migrationBuilder.AddForeignKey(
                name: "FK_sich_sponsor_sponsor_rank_sponsor_rank_id",
                table: "sich_sponsor",
                column: "sponsor_rank_id",
                principalTable: "sponsor_rank",
                principalColumn: "sponsor_rank_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_sich_sponsor_sponsor_rank_sponsor_rank_id",
                table: "sich_sponsor");

            migrationBuilder.DropTable(
                name: "sponsor_rank");

            migrationBuilder.DropIndex(
                name: "IX_sich_sponsor_sponsor_rank_id",
                table: "sich_sponsor");

            migrationBuilder.DropColumn(
                name: "sponsor_rank_id",
                table: "sich_sponsor");

            migrationBuilder.AddColumn<DateTime>(
                name: "expiration",
                table: "sich_sponsor",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
