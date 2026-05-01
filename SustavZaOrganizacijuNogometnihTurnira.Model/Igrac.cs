using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    [Table("Igraci")]
    public class Igrac
    {
        [Key]
        public int IgracId { get; set; }

        [Required]
        [StringLength(60)]
        public string Ime { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        public string Prezime { get; set; } = string.Empty;

        [Range(1, 99)]
        public int BrojDresa { get; set; }

        [Required]
        [StringLength(40)]
        public string Pozicija { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DatumRodjenja { get; set; }

        [Required]
        [StringLength(60)]
        public string Drzava { get; set; } = string.Empty;

        [Column(TypeName = "decimal(4,2)")]
        public decimal Visina { get; set; }

        [ForeignKey(nameof(Ekipa))]
        public int EkipaId { get; set; }

        public virtual Ekipa? Ekipa { get; set; }
    }
}
