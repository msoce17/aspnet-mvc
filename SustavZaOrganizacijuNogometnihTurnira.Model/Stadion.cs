using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    public class Stadion
    {
        public int StadionId { get; set; }
        public string Naziv { get; set; }
        public string Grad { get; set; }
        public int Kapacitet { get; set; }

        // Relacija 1-N sa Utakmicom
        public virtual ICollection<Utakmica> Utakmice { get; set; } = new List<Utakmica>();
    }
}
