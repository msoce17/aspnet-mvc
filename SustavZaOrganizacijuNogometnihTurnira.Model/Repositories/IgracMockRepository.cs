namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class IgracMockRepository
    {
        private static readonly List<Igrac> Igraci =
        [
            new() { IgracId = 1, Ime = "Luka", Prezime = "Modric", Pozicija = "Vezni", BrojDresa = 10, DatumRodjenja = new DateTime(1985, 9, 9), Drzava = "Hrvatska", Visina = 1.72m, EkipaId = 1 },
            new() { IgracId = 2, Ime = "Ivan", Prezime = "Rakitic", Pozicija = "Vezni", BrojDresa = 7, DatumRodjenja = new DateTime(1988, 3, 10), Drzava = "Hrvatska", Visina = 1.84m, EkipaId = 1 },
            new() { IgracId = 3, Ime = "Dejan", Prezime = "Lovren", Pozicija = "Obrana", BrojDresa = 6, DatumRodjenja = new DateTime(1989, 7, 5), Drzava = "Hrvatska", Visina = 1.88m, EkipaId = 1 },
            new() { IgracId = 4, Ime = "Mario", Prezime = "Mandzukic", Pozicija = "Napad", BrojDresa = 9, DatumRodjenja = new DateTime(1986, 5, 21), Drzava = "Hrvatska", Visina = 1.87m, EkipaId = 2 },
            new() { IgracId = 5, Ime = "Marko", Prezime = "Pjaca", Pozicija = "Vezni", BrojDresa = 8, DatumRodjenja = new DateTime(1995, 5, 6), Drzava = "Hrvatska", Visina = 1.80m, EkipaId = 2 },
            new() { IgracId = 6, Ime = "Ante", Prezime = "Budućnost", Pozicija = "Obrana", BrojDresa = 5, DatumRodjenja = new DateTime(1990, 11, 12), Drzava = "Hrvatska", Visina = 1.85m, EkipaId = 2 },
            new() { IgracId = 7, Ime = "Filip", Prezime = "Bradarić", Pozicija = "Vezni", BrojDresa = 14, DatumRodjenja = new DateTime(1992, 3, 10), Drzava = "Hrvatska", Visina = 1.80m, EkipaId = 3 },
            new() { IgracId = 8, Ime = "Mateo", Prezime = "Kovačić", Pozicija = "Vezni", BrojDresa = 11, DatumRodjenja = new DateTime(1994, 5, 6), Drzava = "Hrvatska", Visina = 1.78m, EkipaId = 3 },
            new() { IgracId = 9, Ime = "Domagoj", Prezime = "Vida", Pozicija = "Obrana", BrojDresa = 4, DatumRodjenja = new DateTime(1989, 11, 12), Drzava = "Hrvatska", Visina = 1.85m, EkipaId = 3 },
            new() { IgracId = 10, Ime = "Bruno", Prezime = "Petković", Pozicija = "Napad", BrojDresa = 9, DatumRodjenja = new DateTime(1996, 5, 21), Drzava = "Hrvatska", Visina = 1.87m, EkipaId = 4 },
            new() { IgracId = 11, Ime = "Ante", Prezime = "Vukušić", Pozicija = "Vezni", BrojDresa = 8, DatumRodjenja = new DateTime(1990, 5, 6), Drzava = "Hrvatska", Visina = 1.80m, EkipaId = 4 },
            new() { IgracId = 12, Ime = "Dino", Prezime = "Perić", Pozicija = "Obrana", BrojDresa = 5, DatumRodjenja = new DateTime(1990, 11, 12), Drzava = "Hrvatska", Visina = 1.85m, EkipaId = 4 }
        ];

        public IEnumerable<Igrac> GetAll()
        {
            return Igraci;
        }

        public Igrac? GetById(int id)
        {
            return Igraci.FirstOrDefault(igrac => igrac.IgracId == id);
        }
    }
}
