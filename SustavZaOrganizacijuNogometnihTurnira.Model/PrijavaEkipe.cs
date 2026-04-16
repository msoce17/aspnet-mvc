using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    public class PrijavaEkipe
    {
        public int PrijavaEkipeId { get; set; }
        public DateTime DatumPrijave { get; set; }
        public bool Potvrdjeno { get; set; }

        // Foreign Keys
        public int TurnirId { get; set; }
        public int EkipaId { get; set; }

        // Virtual Properties
        public virtual Turnir Turnir { get; set; }
        public virtual Ekipa Ekipa { get; set; }
    }
}