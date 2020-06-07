using Microsoft.EntityFrameworkCore.Migrations;

namespace Lovid20.Migrations
{
    public partial class Popravka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikUChatu_RegistrovaniKorisnik_korisnikID",
                table: "KorisnikUChatu");

            migrationBuilder.DropForeignKey(
                name: "FK_Recenzija_RegistrovaniKorisnik_korisnik",
                table: "Recenzija");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrovaniKorisnik_Prijava_id",
                table: "RegistrovaniKorisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_TipKorisnika_RegistrovaniKorisnik_id",
                table: "TipKorisnika");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrovaniKorisnik",
                table: "RegistrovaniKorisnik");

            migrationBuilder.DropIndex(
                name: "IX_Recenzija_korisnik",
                table: "Recenzija");

            migrationBuilder.DropColumn(
                name: "id",
                table: "RegistrovaniKorisnik");

            migrationBuilder.AlterColumn<int>(
                name: "idKorisnika",
                table: "RegistrovaniKorisnik",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PrijavaDBid",
                table: "RegistrovaniKorisnik",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrovaniKorisnik",
                table: "RegistrovaniKorisnik",
                column: "idKorisnika");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrovaniKorisnik_PrijavaDBid",
                table: "RegistrovaniKorisnik",
                column: "PrijavaDBid");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_korisnik",
                table: "Recenzija",
                column: "korisnik");

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikUChatu_RegistrovaniKorisnik_korisnikID",
                table: "KorisnikUChatu",
                column: "korisnikID",
                principalTable: "RegistrovaniKorisnik",
                principalColumn: "idKorisnika",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzija_RegistrovaniKorisnik_korisnik",
                table: "Recenzija",
                column: "korisnik",
                principalTable: "RegistrovaniKorisnik",
                principalColumn: "idKorisnika",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrovaniKorisnik_Prijava_PrijavaDBid",
                table: "RegistrovaniKorisnik",
                column: "PrijavaDBid",
                principalTable: "Prijava",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TipKorisnika_RegistrovaniKorisnik_id",
                table: "TipKorisnika",
                column: "id",
                principalTable: "RegistrovaniKorisnik",
                principalColumn: "idKorisnika",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KorisnikUChatu_RegistrovaniKorisnik_korisnikID",
                table: "KorisnikUChatu");

            migrationBuilder.DropForeignKey(
                name: "FK_Recenzija_RegistrovaniKorisnik_korisnik",
                table: "Recenzija");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrovaniKorisnik_Prijava_PrijavaDBid",
                table: "RegistrovaniKorisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_TipKorisnika_RegistrovaniKorisnik_id",
                table: "TipKorisnika");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrovaniKorisnik",
                table: "RegistrovaniKorisnik");

            migrationBuilder.DropIndex(
                name: "IX_RegistrovaniKorisnik_PrijavaDBid",
                table: "RegistrovaniKorisnik");

            migrationBuilder.DropIndex(
                name: "IX_Recenzija_korisnik",
                table: "Recenzija");

            migrationBuilder.DropColumn(
                name: "PrijavaDBid",
                table: "RegistrovaniKorisnik");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "RegistrovaniKorisnik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrovaniKorisnik",
                table: "RegistrovaniKorisnik",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_korisnik",
                table: "Recenzija",
                column: "korisnik",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KorisnikUChatu_RegistrovaniKorisnik_korisnikID",
                table: "KorisnikUChatu",
                column: "korisnikID",
                principalTable: "RegistrovaniKorisnik",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recenzija_RegistrovaniKorisnik_korisnik",
                table: "Recenzija",
                column: "korisnik",
                principalTable: "RegistrovaniKorisnik",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrovaniKorisnik_Prijava_id",
                table: "RegistrovaniKorisnik",
                column: "id",
                principalTable: "Prijava",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TipKorisnika_RegistrovaniKorisnik_id",
                table: "TipKorisnika",
                column: "id",
                principalTable: "RegistrovaniKorisnik",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
