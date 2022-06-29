using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AS_OOP_RacingTeams.Migrations
{
    public partial class MapSponsorShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SponsorShips",
                table: "SponsorShips");

            migrationBuilder.RenameTable(
                name: "SponsorShips",
                newName: "Sponsorship");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sponsorship",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sponsorship",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Sponsorship",
                type: "VARCHAR",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sponsorship",
                table: "Sponsorship",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sponsorship",
                table: "Sponsorship");

            migrationBuilder.RenameTable(
                name: "Sponsorship",
                newName: "SponsorShips");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "SponsorShips",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "SponsorShips",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SponsorShips",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 40);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SponsorShips",
                table: "SponsorShips",
                column: "Id");
        }
    }
}
