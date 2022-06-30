using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AS_OOP_RacingTeams.Migrations
{
    public partial class CreateMapSponsor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sponsorship",
                table: "Sponsorship");

            migrationBuilder.RenameTable(
                name: "Sponsorship",
                newName: "sponsorships");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sponsorships",
                table: "sponsorships",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_sponsorships",
                table: "sponsorships");

            migrationBuilder.RenameTable(
                name: "sponsorships",
                newName: "Sponsorship");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sponsorship",
                table: "Sponsorship",
                column: "id");
        }
    }
}
