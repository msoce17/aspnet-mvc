using SustavZaOrganizacijuNogometnihTurnira.Model.Enums;

namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class TurnirMockRepository
    {
        private static readonly List<Turnir> Turniri =
        [
            new()
            {
                TurnirId = 1,
                Naziv = "Ljetni nogometni turnir",
                DatumPocetka = new DateTime(2024, 7, 1),
                DatumZavrsetka = new DateTime(2024, 7, 15),
                Tip = TipTurnira.Kup,
                Opis = "Ljetni kup turnir za amaterske ekipe.",
                MaximalanBrojEkipa = 16
            },
            new()
            {
                TurnirId = 2,
                Naziv = "Zimski nogometni turnir",
                DatumPocetka = new DateTime(2024, 12, 1),
                DatumZavrsetka = new DateTime(2024, 12, 15),
                Tip = TipTurnira.Ligaski,
                Opis = "Zimski liga turnir za amaterske ekipe.",
                MaximalanBrojEkipa = 2
            },
            new()
            {
                TurnirId = 3,
                Naziv = "Proljetni nogometni turnir",
                DatumPocetka = new DateTime(2024, 3, 1),
                DatumZavrsetka = new DateTime(2024, 3, 15),
                Tip = TipTurnira.Friendly,
                Opis = "Proljetni kup turnir za amaterske ekipe.",
                MaximalanBrojEkipa = 8
            }
        ];

        public IEnumerable<Turnir> GetAll()
        {
            return Turniri;
        }

        public Turnir? GetById(int id)
        {
            return Turniri.FirstOrDefault(turnir => turnir.TurnirId == id);
        }
    }
}
