using SustavZaOrganizacijuNogometnihTurnira.Model;

namespace SustavZaOrganizacijuNogometnihTurnira.Models
{
    public class TurnirTeamsListItemViewModel
    {
        public PrijavaEkipe Prijava { get; set; } = new();
        public Ekipa? Ekipa { get; set; }
        public int BrojIgraca { get; set; }
    }
}
