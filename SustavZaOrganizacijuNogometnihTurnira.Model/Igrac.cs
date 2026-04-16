using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    public class Igrac
    {
        public int IgracId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int BrojDresa { get; set; }
        public string Pozicija { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Drzava { get; set; }
        public decimal Visina { get; set; }

        // Foreign Key - Relacija N-1 sa Ekipom
        public int EkipaId { get; set; }
        public virtual Ekipa Ekipa { get; set; }
    }
}