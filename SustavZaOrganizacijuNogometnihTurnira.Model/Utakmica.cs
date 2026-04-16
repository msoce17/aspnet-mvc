using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    public class Utakmica
    {
        public int UtakmicaId { get; set; }
        public DateTime DatumVrijeme { get; set; }
        public int GoloviDomace { get; set; }
        public int GoloviGosta { get; set; }
        public string Status { get; set; } // Zakazana, U toku, Završena
        public string Napomena { get; set; }

        // Foreign Keys
        public int TurnirId { get; set; }
        public int DomacaEkipaId { get; set; }
        public int GostujucaEkipaId { get; set; }
        public int StadionId { get; set; }
        public int SudacId { get; set; }

        // Virtual Properties (Relacije)
        public virtual Turnir Turnir { get; set; }
        public virtual Ekipa DomacaEkipa { get; set; }
        public virtual Ekipa GostujucaEkipa { get; set; }
        public virtual Stadion Stadion { get; set; }
        public virtual Sudac Sudac { get; set; }
    }
}