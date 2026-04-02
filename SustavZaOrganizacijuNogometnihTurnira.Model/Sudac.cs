using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    public class Sudac
    {
        public int SudacId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Licenca { get; set; }

        // Relacija 1-N sa Utakmicom
        public virtual ICollection<Utakmica> Utakmice { get; set; } = new List<Utakmica>();
    }
}