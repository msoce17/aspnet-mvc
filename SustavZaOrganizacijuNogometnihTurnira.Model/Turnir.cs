using SustavZaOrganizacijuNogometnihTurnira.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    public class Turnir
    {
        public int TurnirId { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public TipTurnira Tip { get; set; }
        public string Opis { get; set; }
        public int MaximalanBrojEkipa { get; set; }

        // Relacije N-N sa Ekipama (preko PrijaveEkipe)
        public virtual ICollection<PrijavaEkipe> PrijaveEkipe { get; set; } = new List<PrijavaEkipe>();

        // Relacija 1-N sa Utakmicama
        public virtual ICollection<Utakmica> Utakmice { get; set; } = new List<Utakmica>();
    }
}