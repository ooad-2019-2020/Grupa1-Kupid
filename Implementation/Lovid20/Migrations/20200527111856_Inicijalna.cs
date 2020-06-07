using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lovid20.Migrations
{
    public partial class Inicijalna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(nullable: true),
                    lozinka = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pratitelji",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    pratitelji = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Prijava",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razlog = table.Column<string>(nullable: true),
                    datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijava", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Poruka",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    chatID = table.Column<int>(nullable: false),
                    datum = table.Column<DateTime>(nullable: false),
                    tekst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Poruka_Chat_chatID",
                        column: x => x.chatID,
                        principalTable: "Chat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistrovaniKorisnik",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    idKorisnika = table.Column<int>(nullable: true),
                    lozinka = table.Column<string>(nullable: true),
                    ime = table.Column<string>(nullable: true),
                    prezime = table.Column<string>(nullable: true),
                    drzava = table.Column<string>(nullable: true),
                    grad = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    slika = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    biografija = table.Column<string>(nullable: true),
                    datumRodjenja = table.Column<DateTime>(nullable: false),
                    spol = table.Column<string>(nullable: true),
                    stanje = table.Column<string>(nullable: true),
                    trajanjeVIP = table.Column<DateTime>(nullable: true),
                    pratitelji = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrovaniKorisnik", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "KorisnikUChatu",
                columns: table => new
                {
                    chatID = table.Column<int>(nullable: false),
                    korisnikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_KorisnikUChatu_Chat_chatID",
                        column: x => x.chatID,
                        principalTable: "Chat",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KorisnikUChatu_RegistrovaniKorisnik_korisnikID",
                        column: x => x.korisnikID,
                        principalTable: "RegistrovaniKorisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnik = table.Column<int>(nullable: false),
                    tekst = table.Column<string>(nullable: true),
                    ocjena = table.Column<int>(nullable: false),
                    datum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.id);
                    table.ForeignKey(
                        name: "FK_Recenzija_RegistrovaniKorisnik_korisnik",
                        column: x => x.korisnik,
                        principalTable: "RegistrovaniKorisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipKorisnika",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipKorisnika", x => x.id);
                    table.ForeignKey(
                        name: "FK_TipKorisnika_RegistrovaniKorisnik_id",
                        column: x => x.id,
                        principalTable: "RegistrovaniKorisnik",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUChatu_chatID",
                table: "KorisnikUChatu",
                column: "chatID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnikUChatu_korisnikID",
                table: "KorisnikUChatu",
                column: "korisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Poruka_chatID",
                table: "Poruka",
                column: "chatID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzija_korisnik",
                table: "Recenzija",
                column: "korisnik",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "KorisnikUChatu");

            migrationBuilder.DropTable(
                name: "Poruka");

            migrationBuilder.DropTable(
                name: "Pratitelji");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "TipKorisnika");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "RegistrovaniKorisnik");

            migrationBuilder.DropTable(
                name: "Prijava");
        }
    }
}
