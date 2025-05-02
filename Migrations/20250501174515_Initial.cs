using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaritimeData.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ships",
                table: "Ships");

            migrationBuilder.DropColumn(
                name: "ArrivalPortName",
                table: "Voyages");

            migrationBuilder.RenameTable(
                name: "Ships",
                newName: "ships");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ships",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MaxSpeed",
                table: "ships",
                newName: "maxspeed");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ships",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "DeparturePortName",
                table: "Voyages",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalPortNames",
                table: "Voyages",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ships",
                table: "ships",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ships",
                table: "ships");

            migrationBuilder.DropColumn(
                name: "ArrivalPortNames",
                table: "Voyages");

            migrationBuilder.RenameTable(
                name: "ships",
                newName: "Ships");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Ships",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "maxspeed",
                table: "Ships",
                newName: "MaxSpeed");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Ships",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "DeparturePortName",
                table: "Voyages",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "ArrivalPortName",
                table: "Voyages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ships",
                table: "Ships",
                column: "Id");
        }
    }
}
