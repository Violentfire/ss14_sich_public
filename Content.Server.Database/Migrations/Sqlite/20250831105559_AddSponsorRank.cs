using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Content.Server.Database.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class AddSponsorRank : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sponsor_rank",
                columns: table => new
                {
                    sponsor_rank_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sponsor_rank", x => x.sponsor_rank_id);
                });

            migrationBuilder.CreateTable(
                name: "sich_sponsor",
                columns: table => new
                {
                    sich_sponsor_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    user_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    sponsor_level = table.Column<string>(type: "TEXT", nullable: false),
                    sponsor_rank_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sich_sponsor", x => x.sich_sponsor_id);
                    table.ForeignKey(
                        name: "FK_sich_sponsor_sponsor_rank_sponsor_rank_id",
                        column: x => x.sponsor_rank_id,
                        principalTable: "sponsor_rank",
                        principalColumn: "sponsor_rank_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_sich_sponsor_sponsor_rank_id",
                table: "sich_sponsor",
                column: "sponsor_rank_id");

            migrationBuilder.CreateIndex(
                name: "IX_sich_sponsor_user_id",
                table: "sich_sponsor",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sich_sponsor");

            migrationBuilder.DropTable(
                name: "sponsor_rank");
        }
    }
}
