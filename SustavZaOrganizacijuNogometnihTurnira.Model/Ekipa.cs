using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    public class Ekipa
    {
        public int EkipaId { get; set; }
        public string Naziv { get; set; }
        public string Grad { get; set; }
        public DateTime DatumOsnutka { get; set; }
        public string TrenerIme { get; set; }
        public int BrojIgraca { get; set; }
        public string Kontakt { get; set; }

        // Relacije N-N sa Turnirima (preko PrijaveEkipe)
        public virtual ICollection<PrijavaEkipe> PrijaveEkipe { get; set; } = new List<PrijavaEkipe>();

        // Relacija 1-N sa Igracima
        public virtual ICollection<Igrac> Igraci { get; set; } = new List<Igrac>();

        // Relacija 1-N sa Utakmicama (kao domaca ekipa)
        public virtual ICollection<Utakmica> DomaceUtakmice { get; set; } = new List<Utakmica>();

        // Relacija 1-N sa Utakmicama (kao gostujuca ekipa)
        public virtual ICollection<Utakmica> GostujuceUtakmice { get; set; } = new List<Utakmica>();
    }
}