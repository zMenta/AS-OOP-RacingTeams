using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AS_OOP_RacingTeams.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "jobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jobs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sponsorShips",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sponsorShips", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Cnpj = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "VARCHAR", maxLength: 40, nullable: false),
                    birth_year = table.Column<int>(type: "integer", nullable: false),
                    job_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.id);
                    table.ForeignKey(
                        name: "FK_persons_jobs_job_id",
                        column: x => x.job_id,
                        principalTable: "jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SponsorShipTeam",
                columns: table => new
                {
                    SponsorShipsId = table.Column<int>(type: "integer", nullable: false),
                    TeamsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorShipTeam", x => new { x.SponsorShipsId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_SponsorShipTeam_sponsorShips_SponsorShipsId",
                        column: x => x.SponsorShipsId,
                        principalTable: "sponsorShips",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SponsorShipTeam_Team_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonTeam",
                columns: table => new
                {
                    PersonsId = table.Column<int>(type: "integer", nullable: false),
                    TeamsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTeam", x => new { x.PersonsId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_PersonTeam_persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonTeam_Team_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_persons_job_id",
                table: "persons",
                column: "job_id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonTeam_TeamsId",
                table: "PersonTeam",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_SponsorShipTeam_TeamsId",
                table: "SponsorShipTeam",
                column: "TeamsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonTeam");

            migrationBuilder.DropTable(
                name: "SponsorShipTeam");

            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.DropTable(
                name: "sponsorShips");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "jobs");
        }
    }
}
