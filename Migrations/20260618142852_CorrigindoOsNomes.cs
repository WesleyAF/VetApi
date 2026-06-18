using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApi.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoOsNomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Donos_DonoIdId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Animals_AnimalIdId",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "AnimalIdId",
                table: "Consultas",
                newName: "AnimalId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_AnimalIdId",
                table: "Consultas",
                newName: "IX_Consultas_AnimalId");

            migrationBuilder.RenameColumn(
                name: "DonoIdId",
                table: "Animals",
                newName: "DonoId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_DonoIdId",
                table: "Animals",
                newName: "IX_Animals_DonoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Donos_DonoId",
                table: "Animals",
                column: "DonoId",
                principalTable: "Donos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Animals_AnimalId",
                table: "Consultas",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Donos_DonoId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Animals_AnimalId",
                table: "Consultas");

            migrationBuilder.RenameColumn(
                name: "AnimalId",
                table: "Consultas",
                newName: "AnimalIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Consultas_AnimalId",
                table: "Consultas",
                newName: "IX_Consultas_AnimalIdId");

            migrationBuilder.RenameColumn(
                name: "DonoId",
                table: "Animals",
                newName: "DonoIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Animals_DonoId",
                table: "Animals",
                newName: "IX_Animals_DonoIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Donos_DonoIdId",
                table: "Animals",
                column: "DonoIdId",
                principalTable: "Donos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Animals_AnimalIdId",
                table: "Consultas",
                column: "AnimalIdId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
