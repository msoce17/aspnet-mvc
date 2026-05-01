using SustavZaOrganizacijuNogometnihTurnira.Model;

namespace SustavZaOrganizacijuNogometnihTurnira.Models
{
    public class TurnirTeamsListViewModel
    {
        public Turnir Turnir { get; set; } = new();
        public IEnumerable<TurnirTeamsListItemViewModel> Stavke { get; set; } = [];
    }
}
