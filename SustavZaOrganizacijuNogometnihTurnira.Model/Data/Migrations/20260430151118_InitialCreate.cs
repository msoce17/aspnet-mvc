using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SustavZaOrganizacijuNogometnihTurnira.Model.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ekipe",
                columns: table => new
                {
                    EkipaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Grad = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DatumOsnutka = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TrenerIme = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    BrojIgraca = table.Column<int>(type: "INTEGER", nullable: false),
                    Kontakt = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ekipe", x => x.EkipaId);
                });

            migrationBuilder.CreateTable(
                name: "Stadioni",
                columns: table => new
                {
                    StadionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Grad = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Kapacitet = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadioni", x => x.StadionId);
                });

            migrationBuilder.CreateTable(
                name: "Sudci",
                columns: table => new
                {
                    SudacId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Prezime = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Licenca = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sudci", x => x.SudacId);
                });

            migrationBuilder.CreateTable(
                name: "Turniri",
                columns: table => new
                {
                    TurnirId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    DatumPocetka = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Tip = table.Column<int>(type: "INTEGER", nullable: false),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    MaximalanBrojEkipa = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turniri", x => x.TurnirId);
                });

            migrationBuilder.CreateTable(
                name: "Igraci",
                columns: table => new
                {
                    IgracId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Prezime = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    BrojDresa = table.Column<int>(type: "INTEGER", nullable: false),
                    Pozicija = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Drzava = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Visina = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    EkipaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igraci", x => x.IgracId);
                    table.ForeignKey(
                        name: "FK_Igraci_Ekipe_EkipaId",
                        column: x => x.EkipaId,
                        principalTable: "Ekipe",
                        principalColumn: "EkipaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrijaveEkipe",
                columns: table => new
                {
                    PrijavaEkipeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DatumPrijave = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Potvrdjeno = table.Column<bool>(type: "INTEGER", nullable: false),
                    TurnirId = table.Column<int>(type: "INTEGER", nullable: false),
                    EkipaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrijaveEkipe", x => x.PrijavaEkipeId);
                    table.ForeignKey(
                        name: "FK_PrijaveEkipe_Ekipe_EkipaId",
                        column: x => x.EkipaId,
                        principalTable: "Ekipe",
                        principalColumn: "EkipaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrijaveEkipe_Turniri_TurnirId",
                        column: x => x.TurnirId,
                        principalTable: "Turniri",
                        principalColumn: "TurnirId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utakmice",
                columns: table => new
                {
                    UtakmicaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DatumVrijeme = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GoloviDomace = table.Column<int>(type: "INTEGER", nullable: false),
                    GoloviGosta = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Napomena = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    TurnirId = table.Column<int>(type: "INTEGER", nullable: false),
                    DomacaEkipaId = table.Column<int>(type: "INTEGER", nullable: false),
                    GostujucaEkipaId = table.Column<int>(type: "INTEGER", nullable: false),
                    StadionId = table.Column<int>(type: "INTEGER", nullable: false),
                    SudacId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utakmice", x => x.UtakmicaId);
                    table.ForeignKey(
                        name: "FK_Utakmice_Ekipe_DomacaEkipaId",
                        column: x => x.DomacaEkipaId,
                        principalTable: "Ekipe",
                        principalColumn: "EkipaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Utakmice_Ekipe_GostujucaEkipaId",
                        column: x => x.GostujucaEkipaId,
                        principalTable: "Ekipe",
                        principalColumn: "EkipaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Utakmice_Stadioni_StadionId",
                        column: x => x.StadionId,
                        principalTable: "Stadioni",
                        principalColumn: "StadionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utakmice_Sudci_SudacId",
                        column: x => x.SudacId,
                        principalTable: "Sudci",
                        principalColumn: "SudacId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utakmice_Turniri_TurnirId",
                        column: x => x.TurnirId,
                        principalTable: "Turniri",
                        principalColumn: "TurnirId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ekipe",
                columns: new[] { "EkipaId", "BrojIgraca", "DatumOsnutka", "Grad", "Kontakt", "Naziv", "TrenerIme" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(1903, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zagreb", "0123456789", "NK Zagreb", "Ante" },
                    { 2, 3, new DateTime(1912, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Split", "0987654321", "HNK Split", "Miroslav" },
                    { 3, 3, new DateTime(1946, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rijeka", "0112233445", "NK Rijeka", "Zoran" },
                    { 4, 3, new DateTime(1947, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osijek", "0223344556", "HNK Osijek", "Dario" }
                });

            migrationBuilder.InsertData(
                table: "Stadioni",
                columns: new[] { "StadionId", "Grad", "Kapacitet", "Naziv" },
                values: new object[,]
                {
                    { 1, "Zagreb", 35000, "Stadion Maksimir" },
                    { 2, "Split", 18000, "Stadion Poljud" },
                    { 3, "Rijeka", 20000, "Gradski stadion" }
                });

            migrationBuilder.InsertData(
                table: "Sudci",
                columns: new[] { "SudacId", "Ime", "Licenca", "Prezime" },
                values: new object[,]
                {
                    { 1, "Marko", "UEFA-A", "Horvat" },
                    { 2, "Ivan", "UEFA-B", "Milic" },
                    { 3, "Petar", "UEFA-A", "Novak" }
                });

            migrationBuilder.InsertData(
                table: "Turniri",
                columns: new[] { "TurnirId", "DatumPocetka", "DatumZavrsetka", "MaximalanBrojEkipa", "Naziv", "Opis", "Tip" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Ljetni nogometni turnir", "Ljetni kup turnir za amaterske ekipe.", 4 },
                    { 2, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Zimski nogometni turnir", "Zimski liga turnir za amaterske ekipe.", 3 },
                    { 3, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Proljetni nogometni turnir", "Proljetni kup turnir za amaterske ekipe.", 1 }
                });

            migrationBuilder.InsertData(
                table: "Igraci",
                columns: new[] { "IgracId", "BrojDresa", "DatumRodjenja", "Drzava", "EkipaId", "Ime", "Pozicija", "Prezime", "Visina" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(1985, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 1, "Luka", "Vezni", "Modric", 1.72m },
                    { 2, 7, new DateTime(1988, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 1, "Ivan", "Vezni", "Rakitic", 1.84m },
                    { 3, 6, new DateTime(1989, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 1, "Dejan", "Obrana", "Lovren", 1.88m },
                    { 4, 9, new DateTime(1986, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 2, "Mario", "Napad", "Mandzukic", 1.87m },
                    { 5, 8, new DateTime(1995, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 2, "Marko", "Vezni", "Pjaca", 1.80m },
                    { 6, 5, new DateTime(1990, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 2, "Ante", "Obrana", "Buducnost", 1.85m },
                    { 7, 14, new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 3, "Filip", "Vezni", "Bradaric", 1.80m },
                    { 8, 11, new DateTime(1994, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 3, "Mateo", "Vezni", "Kovacic", 1.78m },
                    { 9, 4, new DateTime(1989, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 3, "Domagoj", "Obrana", "Vida", 1.85m },
                    { 10, 9, new DateTime(1996, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 4, "Bruno", "Napad", "Petkovic", 1.87m },
                    { 11, 8, new DateTime(1990, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 4, "Ante", "Vezni", "Vukusic", 1.80m },
                    { 12, 5, new DateTime(1990, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hrvatska", 4, "Dino", "Obrana", "Peric", 1.85m }
                });

            migrationBuilder.InsertData(
                table: "PrijaveEkipe",
                columns: new[] { "PrijavaEkipeId", "DatumPrijave", "EkipaId", "Potvrdjeno", "TurnirId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 1 },
                    { 2, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 1 },
                    { 3, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 2 },
                    { 4, new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 2 },
                    { 5, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 3 },
                    { 6, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 3 }
                });

            migrationBuilder.InsertData(
                table: "Utakmice",
                columns: new[] { "UtakmicaId", "DatumVrijeme", "DomacaEkipaId", "GoloviDomace", "GoloviGosta", "GostujucaEkipaId", "Napomena", "StadionId", "Status", "SudacId", "TurnirId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1, 2, "Dobra utakmica, puno navijaca.", 1, "Zavrsena", 1, 1 },
                    { 2, new DateTime(2024, 12, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 1, 4, "Izjednacena utakmica.", 2, "Zavrsena", 2, 2 },
                    { 3, new DateTime(2024, 3, 3, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, 2, 3, "Dobra utakmica, ali domacini nisu uspjeli postici gol.", 3, "Zavrsena", 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Igraci_EkipaId",
                table: "Igraci",
                column: "EkipaId");

            migrationBuilder.CreateIndex(
                name: "IX_PrijaveEkipe_EkipaId",
                table: "PrijaveEkipe",
                column: "EkipaId");

            migrationBuilder.CreateIndex(
                name: "IX_PrijaveEkipe_TurnirId",
                table: "PrijaveEkipe",
                column: "TurnirId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_DomacaEkipaId",
                table: "Utakmice",
                column: "DomacaEkipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_GostujucaEkipaId",
                table: "Utakmice",
                column: "GostujucaEkipaId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_StadionId",
                table: "Utakmice",
                column: "StadionId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_SudacId",
                table: "Utakmice",
                column: "SudacId");

            migrationBuilder.CreateIndex(
                name: "IX_Utakmice_TurnirId",
                table: "Utakmice",
                column: "TurnirId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Igraci");

            migrationBuilder.DropTable(
                name: "PrijaveEkipe");

            migrationBuilder.DropTable(
                name: "Utakmice");

            migrationBuilder.DropTable(
                name: "Ekipe");

            migrationBuilder.DropTable(
                name: "Stadioni");

            migrationBuilder.DropTable(
                name: "Sudci");

            migrationBuilder.DropTable(
                name: "Turniri");
        }
    }
}
