using SustavZaOrganizacijuNogometnihTurnira.Model;

namespace SustavZaOrganizacijuNogometnihTurnira.Models
{
    public class IgracDetailsViewModel
    {
        public Igrac Igrac { get; set; } = new();
        public Ekipa? Ekipa { get; set; }
    }
}
