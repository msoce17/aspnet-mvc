using SustavZaOrganizacijuNogometnihTurnira.Model;

namespace SustavZaOrganizacijuNogometnihTurnira.Models
{
    public class EkipaDetailsViewModel
    {
        public Ekipa Ekipa { get; set; } = new();
        public IEnumerable<Igrac> Igraci { get; set; } = [];
    }
}
