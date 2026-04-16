using SustavZaOrganizacijuNogometnihTurnira.Model;

namespace SustavZaOrganizacijuNogometnihTurnira.Models
{
    public class UtakmicaViewModel
    {
        public Utakmica Utakmica { get; set; } = new();
        public Turnir? Turnir { get; set; }
        public Ekipa? DomacaEkipa { get; set; }
        public Ekipa? GostujucaEkipa { get; set; }
        public Stadion? Stadion { get; set; }
        public Sudac? Sudac { get; set; }
    }
}
