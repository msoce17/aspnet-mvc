namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class EkipaMockRepository
    {
        private static readonly List<Ekipa> Ekipe =
        [
            new()
            {
                EkipaId = 1,
                Naziv = "NK Zagreb",
                Grad = "Zagreb",
                DatumOsnutka = new DateTime(1903, 6, 1),
                TrenerIme = "Ante",
                BrojIgraca = 3,
                Kontakt = "0123456789"
            },
            new()
            {
                EkipaId = 2,
                Naziv = "HNK Split",
                Grad = "Split",
                DatumOsnutka = new DateTime(1912, 4, 16),
                TrenerIme = "Miroslav",
                BrojIgraca = 3,
                Kontakt = "0987654321"
            },
            new()
            {
                EkipaId = 3,
                Naziv = "NK Rijeka",
                Grad = "Rijeka",
                DatumOsnutka = new DateTime(1946, 6, 29),
                TrenerIme = "Zoran",
                BrojIgraca = 3,
                Kontakt = "0112233445"
            },
            new()
            {
                EkipaId = 4,
                Naziv = "HNK Osijek",
                Grad = "Osijek",
                DatumOsnutka = new DateTime(1947, 5, 27),
                TrenerIme = "Dario",
                BrojIgraca = 3,
                Kontakt = "0223344556"
            }
        ];

        public IEnumerable<Ekipa> GetAll()
        {
            return Ekipe;
        }

        public Ekipa? GetById(int id)
        {
            return Ekipe.FirstOrDefault(ekipa => ekipa.EkipaId == id);
        }
    }
}
