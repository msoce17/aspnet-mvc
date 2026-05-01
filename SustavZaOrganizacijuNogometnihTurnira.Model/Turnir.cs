using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SustavZaOrganizacijuNogometnihTurnira.Model.Enums;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    [Table("Turniri")]
    public class Turnir
    {
        [Key]
        public int TurnirId { get; set; }

        [Required]
        [StringLength(120)]
        public string Naziv { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DatumPocetka { get; set; }

        [DataType(DataType.Date)]
        public DateTime DatumZavrsetka { get; set; }

        public TipTurnira Tip { get; set; }

        [Required]
        [StringLength(500)]
        public string Opis { get; set; } = string.Empty;

        [Range(2, 64)]
        public int MaximalanBrojEkipa { get; set; }

        [InverseProperty(nameof(PrijavaEkipe.Turnir))]
        public virtual ICollection<PrijavaEkipe> PrijaveEkipe { get; set; } = new List<PrijavaEkipe>();

        [InverseProperty(nameof(Utakmica.Turnir))]
        public virtual ICollection<Utakmica> Utakmice { get; set; } = new List<Utakmica>();
    }
}
