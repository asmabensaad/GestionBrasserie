using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionBrasserie.Migrations
{
    public partial class secondMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventes_Bieres_BiereId",
                table: "Ventes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ventes_Grossistes_IdGr",
                table: "Ventes");

            migrationBuilder.DropIndex(
                name: "IX_Ventes_BiereId",
                table: "Ventes");

            migrationBuilder.DropIndex(
                name: "IX_Ventes_IdGr",
                table: "Ventes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ventes_BiereId",
                table: "Ventes",
                column: "BiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Ventes_IdGr",
                table: "Ventes",
                column: "IdGr");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventes_Bieres_BiereId",
                table: "Ventes",
                column: "BiereId",
                principalTable: "Bieres",
                principalColumn: "BiereId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ventes_Grossistes_IdGr",
                table: "Ventes",
                column: "IdGr",
                principalTable: "Grossistes",
                principalColumn: "IdGr",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
