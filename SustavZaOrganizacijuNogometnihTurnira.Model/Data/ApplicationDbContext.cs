using Microsoft.EntityFrameworkCore;
using SustavZaOrganizacijuNogometnihTurnira.Model.Enums;

namespace SustavZaOrganizacijuNogometnihTurnira.Model.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ekipa> Ekipe => Set<Ekipa>();
        public DbSet<Igrac> Igraci => Set<Igrac>();
        public DbSet<PrijavaEkipe> PrijaveEkipe => Set<PrijavaEkipe>();
        public DbSet<Stadion> Stadioni => Set<Stadion>();
        public DbSet<Sudac> Sudci => Set<Sudac>();
        public DbSet<Turnir> Turniri => Set<Turnir>();
        public DbSet<Utakmica> Utakmice => Set<Utakmica>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Utakmica>()
                .HasOne(utakmica => utakmica.DomacaEkipa)
                .WithMany(ekipa => ekipa.DomaceUtakmice)
                .HasForeignKey(utakmica => utakmica.DomacaEkipaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Utakmica>()
                .HasOne(utakmica => utakmica.GostujucaEkipa)
                .WithMany(ekipa => ekipa.GostujuceUtakmice)
                .HasForeignKey(utakmica => utakmica.GostujucaEkipaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Igrac>()
                .Property(igrac => igrac.Visina)
                .HasPrecision(4, 2);

            modelBuilder.Entity<Turnir>().HasData(
                new Turnir
                {
                    TurnirId = 1,
                    Naziv = "Ljetni nogometni turnir",
                    DatumPocetka = new DateTime(2024, 7, 1),
                    DatumZavrsetka = new DateTime(2024, 7, 15),
                    Tip = TipTurnira.Kup,
                    Opis = "Ljetni kup turnir za amaterske ekipe.",
                    MaximalanBrojEkipa = 16
                },
                new Turnir
                {
                    TurnirId = 2,
                    Naziv = "Zimski nogometni turnir",
                    DatumPocetka = new DateTime(2024, 12, 1),
                    DatumZavrsetka = new DateTime(2024, 12, 15),
                    Tip = TipTurnira.Ligaski,
                    Opis = "Zimski liga turnir za amaterske ekipe.",
                    MaximalanBrojEkipa = 2
                },
                new Turnir
                {
                    TurnirId = 3,
                    Naziv = "Proljetni nogometni turnir",
                    DatumPocetka = new DateTime(2024, 3, 1),
                    DatumZavrsetka = new DateTime(2024, 3, 15),
                    Tip = TipTurnira.Friendly,
                    Opis = "Proljetni kup turnir za amaterske ekipe.",
                    MaximalanBrojEkipa = 8
                });

            modelBuilder.Entity<Ekipa>().HasData(
                new Ekipa { EkipaId = 1, Naziv = "NK Zagreb", Grad = "Zagreb", DatumOsnutka = new DateTime(1903, 6, 1), TrenerIme = "Ante", BrojIgraca = 3, Kontakt = "0123456789" },
                new Ekipa { EkipaId = 2, Naziv = "HNK Split", Grad = "Split", DatumOsnutka = new DateTime(1912, 4, 16), TrenerIme = "Miroslav", BrojIgraca = 3, Kontakt = "0987654321" },
                new Ekipa { EkipaId = 3, Naziv = "NK Rijeka", Grad = "Rijeka", DatumOsnutka = new DateTime(1946, 6, 29), TrenerIme = "Zoran", BrojIgraca = 3, Kontakt = "0112233445" },
                new Ekipa { EkipaId = 4, Naziv = "HNK Osijek", Grad = "Osijek", DatumOsnutka = new DateTime(1947, 5, 27), TrenerIme = "Dario", BrojIgraca = 3, Kontakt = "0223344556" });

            modelBuilder.Entity<Igrac>().HasData(
                new Igrac { IgracId = 1, Ime = "Luka", Prezime = "Modric", Pozicija = "Vezni", BrojDresa = 10, DatumRodjenja = new DateTime(1985, 9, 9), Drzava = "Hrvatska", Visina = 1.72m, EkipaId = 1 },
                new Igrac { IgracId = 2, Ime = "Ivan", Prezime = "Rakitic", Pozicija = "Vezni", BrojDresa = 7, DatumRodjenja = new DateTime(1988, 3, 10), Drzava = "Hrvatska", Visina = 1.84m, EkipaId = 1 },
                new Igrac { IgracId = 3, Ime = "Dejan", Prezime = "Lovren", Pozicija = "Obrana", BrojDresa = 6, DatumRodjenja = new DateTime(1989, 7, 5), Drzava = "Hrvatska", Visina = 1.88m, EkipaId = 1 },
                new Igrac { IgracId = 4, Ime = "Mario", Prezime = "Mandzukic", Pozicija = "Napad", BrojDresa = 9, DatumRodjenja = new DateTime(1986, 5, 21), Drzava = "Hrvatska", Visina = 1.87m, EkipaId = 2 },
                new Igrac { IgracId = 5, Ime = "Marko", Prezime = "Pjaca", Pozicija = "Vezni", BrojDresa = 8, DatumRodjenja = new DateTime(1995, 5, 6), Drzava = "Hrvatska", Visina = 1.80m, EkipaId = 2 },
                new Igrac { IgracId = 6, Ime = "Ante", Prezime = "Buducnost", Pozicija = "Obrana", BrojDresa = 5, DatumRodjenja = new DateTime(1990, 11, 12), Drzava = "Hrvatska", Visina = 1.85m, EkipaId = 2 },
                new Igrac { IgracId = 7, Ime = "Filip", Prezime = "Bradaric", Pozicija = "Vezni", BrojDresa = 14, DatumRodjenja = new DateTime(1992, 3, 10), Drzava = "Hrvatska", Visina = 1.80m, EkipaId = 3 },
                new Igrac { IgracId = 8, Ime = "Mateo", Prezime = "Kovacic", Pozicija = "Vezni", BrojDresa = 11, DatumRodjenja = new DateTime(1994, 5, 6), Drzava = "Hrvatska", Visina = 1.78m, EkipaId = 3 },
                new Igrac { IgracId = 9, Ime = "Domagoj", Prezime = "Vida", Pozicija = "Obrana", BrojDresa = 4, DatumRodjenja = new DateTime(1989, 11, 12), Drzava = "Hrvatska", Visina = 1.85m, EkipaId = 3 },
                new Igrac { IgracId = 10, Ime = "Bruno", Prezime = "Petkovic", Pozicija = "Napad", BrojDresa = 9, DatumRodjenja = new DateTime(1996, 5, 21), Drzava = "Hrvatska", Visina = 1.87m, EkipaId = 4 },
                new Igrac { IgracId = 11, Ime = "Ante", Prezime = "Vukusic", Pozicija = "Vezni", BrojDresa = 8, DatumRodjenja = new DateTime(1990, 5, 6), Drzava = "Hrvatska", Visina = 1.80m, EkipaId = 4 },
                new Igrac { IgracId = 12, Ime = "Dino", Prezime = "Peric", Pozicija = "Obrana", BrojDresa = 5, DatumRodjenja = new DateTime(1990, 11, 12), Drzava = "Hrvatska", Visina = 1.85m, EkipaId = 4 });

            modelBuilder.Entity<Stadion>().HasData(
                new Stadion { StadionId = 1, Naziv = "Stadion Maksimir", Grad = "Zagreb", Kapacitet = 35000 },
                new Stadion { StadionId = 2, Naziv = "Stadion Poljud", Grad = "Split", Kapacitet = 18000 },
                new Stadion { StadionId = 3, Naziv = "Gradski stadion", Grad = "Rijeka", Kapacitet = 20000 });

            modelBuilder.Entity<Sudac>().HasData(
                new Sudac { SudacId = 1, Ime = "Marko", Prezime = "Horvat", Licenca = "UEFA-A" },
                new Sudac { SudacId = 2, Ime = "Ivan", Prezime = "Milic", Licenca = "UEFA-B" },
                new Sudac { SudacId = 3, Ime = "Petar", Prezime = "Novak", Licenca = "UEFA-A" });

            modelBuilder.Entity<PrijavaEkipe>().HasData(
                new PrijavaEkipe { PrijavaEkipeId = 1, TurnirId = 1, EkipaId = 1, DatumPrijave = new DateTime(2024, 6, 1), Potvrdjeno = true },
                new PrijavaEkipe { PrijavaEkipeId = 2, TurnirId = 1, EkipaId = 2, DatumPrijave = new DateTime(2024, 6, 2), Potvrdjeno = true },
                new PrijavaEkipe { PrijavaEkipeId = 3, TurnirId = 2, EkipaId = 3, DatumPrijave = new DateTime(2024, 11, 1), Potvrdjeno = true },
                new PrijavaEkipe { PrijavaEkipeId = 4, TurnirId = 2, EkipaId = 4, DatumPrijave = new DateTime(2024, 11, 2), Potvrdjeno = true },
                new PrijavaEkipe { PrijavaEkipeId = 5, TurnirId = 3, EkipaId = 1, DatumPrijave = new DateTime(2024, 2, 1), Potvrdjeno = true },
                new PrijavaEkipe { PrijavaEkipeId = 6, TurnirId = 3, EkipaId = 3, DatumPrijave = new DateTime(2024, 2, 2), Potvrdjeno = true });

            modelBuilder.Entity<Utakmica>().HasData(
                new Utakmica
                {
                    UtakmicaId = 1,
                    TurnirId = 1,
                    DomacaEkipaId = 1,
                    GostujucaEkipaId = 2,
                    DatumVrijeme = new DateTime(2024, 7, 3, 18, 0, 0),
                    StadionId = 1,
                    SudacId = 1,
                    GoloviDomace = 2,
                    GoloviGosta = 1,
                    Status = "Zavrsena",
                    Napomena = "Dobra utakmica, puno navijaca."
                },
                new Utakmica
                {
                    UtakmicaId = 2,
                    TurnirId = 2,
                    DomacaEkipaId = 3,
                    GostujucaEkipaId = 4,
                    DatumVrijeme = new DateTime(2024, 12, 3, 18, 0, 0),
                    StadionId = 2,
                    SudacId = 2,
                    GoloviDomace = 1,
                    GoloviGosta = 1,
                    Status = "Zavrsena",
                    Napomena = "Izjednacena utakmica."
                },
                new Utakmica
                {
                    UtakmicaId = 3,
                    TurnirId = 3,
                    DomacaEkipaId = 1,
                    GostujucaEkipaId = 3,
                    DatumVrijeme = new DateTime(2024, 3, 3, 18, 0, 0),
                    StadionId = 3,
                    SudacId = 3,
                    GoloviDomace = 0,
                    GoloviGosta = 2,
                    Status = "Zavrsena",
                    Napomena = "Dobra utakmica, ali domacini nisu uspjeli postici gol."
                });
        }
    }
}
