using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    [Table("Utakmice")]
    public class Utakmica
    {
        [Key]
        public int UtakmicaId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DatumVrijeme { get; set; }

        [Range(0, 99)]
        public int GoloviDomace { get; set; }

        [Range(0, 99)]
        public int GoloviGosta { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; } = string.Empty;

        [StringLength(500)]
        public string Napomena { get; set; } = string.Empty;

        [ForeignKey(nameof(Turnir))]
        public int TurnirId { get; set; }

        [ForeignKey(nameof(DomacaEkipa))]
        public int DomacaEkipaId { get; set; }

        [ForeignKey(nameof(GostujucaEkipa))]
        public int GostujucaEkipaId { get; set; }

        [ForeignKey(nameof(Stadion))]
        public int StadionId { get; set; }

        [ForeignKey(nameof(Sudac))]
        public int SudacId { get; set; }

        public virtual Turnir? Turnir { get; set; }
        public virtual Ekipa? DomacaEkipa { get; set; }
        public virtual Ekipa? GostujucaEkipa { get; set; }
        public virtual Stadion? Stadion { get; set; }
        public virtual Sudac? Sudac { get; set; }
    }
}
