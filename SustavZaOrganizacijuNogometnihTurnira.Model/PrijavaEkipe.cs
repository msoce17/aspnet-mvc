using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    [Table("PrijaveEkipe")]
    public class PrijavaEkipe
    {
        [Key]
        public int PrijavaEkipeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumPrijave { get; set; }

        public bool Potvrdjeno { get; set; }

        [ForeignKey(nameof(Turnir))]
        public int TurnirId { get; set; }

        [ForeignKey(nameof(Ekipa))]
        public int EkipaId { get; set; }

        public virtual Turnir? Turnir { get; set; }
        public virtual Ekipa? Ekipa { get; set; }
    }
}
