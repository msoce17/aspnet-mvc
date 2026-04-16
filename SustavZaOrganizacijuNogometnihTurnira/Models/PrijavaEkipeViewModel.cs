using SustavZaOrganizacijuNogometnihTurnira.Model;

namespace SustavZaOrganizacijuNogometnihTurnira.Models
{
    public class PrijavaEkipeViewModel
    {
        public PrijavaEkipe Prijava { get; set; } = new();
        public Turnir? Turnir { get; set; }
        public Ekipa? Ekipa { get; set; }
    }
}
