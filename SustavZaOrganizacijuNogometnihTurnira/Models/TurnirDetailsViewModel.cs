using SustavZaOrganizacijuNogometnihTurnira.Model;

namespace SustavZaOrganizacijuNogometnihTurnira.Models
{
    public class TurnirDetailsViewModel
    {
        public Turnir Turnir { get; set; } = new();
        public IEnumerable<TurnirPrijavaViewModel> PrijaveEkipe { get; set; } = [];
        public IEnumerable<TurnirUtakmicaViewModel> Utakmice { get; set; } = [];
        public int UkupnoIgraca { get; set; }
    }

    public class TurnirPrijavaViewModel
    {
        public PrijavaEkipe Prijava { get; set; } = new();
        public Ekipa? Ekipa { get; set; }
        public IEnumerable<Igrac> Igraci { get; set; } = [];
    }

    public class TurnirUtakmicaViewModel
    {
        public Utakmica Utakmica { get; set; } = new();
        public Ekipa? DomacaEkipa { get; set; }
        public Ekipa? GostujucaEkipa { get; set; }
        public Stadion? Stadion { get; set; }
        public Sudac? Sudac { get; set; }
    }
}
