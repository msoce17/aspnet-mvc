namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class PrijavaEkipeMockRepository
    {
        private static readonly List<PrijavaEkipe> PrijaveEkipe =
        [
            new() { PrijavaEkipeId = 1, TurnirId = 1, EkipaId = 1, DatumPrijave = new DateTime(2024, 6, 1), Potvrdjeno = true },
            new() { PrijavaEkipeId = 2, TurnirId = 1, EkipaId = 2, DatumPrijave = new DateTime(2024, 6, 2), Potvrdjeno = true },
            new() { PrijavaEkipeId = 3, TurnirId = 2, EkipaId = 3, DatumPrijave = new DateTime(2024, 11, 1), Potvrdjeno = true },
            new() { PrijavaEkipeId = 4, TurnirId = 2, EkipaId = 4, DatumPrijave = new DateTime(2024, 11, 2), Potvrdjeno = true },
            new() { PrijavaEkipeId = 5, TurnirId = 3, EkipaId = 1, DatumPrijave = new DateTime(2024, 2, 1), Potvrdjeno = true },
            new() { PrijavaEkipeId = 6, TurnirId = 3, EkipaId = 3, DatumPrijave = new DateTime(2024, 2, 2), Potvrdjeno = true }
        ];

        public IEnumerable<PrijavaEkipe> GetAll()
        {
            return PrijaveEkipe;
        }

        public PrijavaEkipe? GetById(int id)
        {
            return PrijaveEkipe.FirstOrDefault(prijava => prijava.PrijavaEkipeId == id);
        }
    }
}
