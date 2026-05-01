using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    [Table("Ekipe")]
    public class Ekipa
    {
        [Key]
        public int EkipaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Naziv { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Grad { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DatumOsnutka { get; set; }

        [Required]
        [StringLength(100)]
        public string TrenerIme { get; set; } = string.Empty;

        [Range(0, 99)]
        public int BrojIgraca { get; set; }

        [Required]
        [StringLength(50)]
        public string Kontakt { get; set; } = string.Empty;

        [InverseProperty(nameof(PrijavaEkipe.Ekipa))]
        public virtual ICollection<PrijavaEkipe> PrijaveEkipe { get; set; } = new List<PrijavaEkipe>();

        [InverseProperty(nameof(Igrac.Ekipa))]
        public virtual ICollection<Igrac> Igraci { get; set; } = new List<Igrac>();

        [InverseProperty(nameof(Utakmica.DomacaEkipa))]
        public virtual ICollection<Utakmica> DomaceUtakmice { get; set; } = new List<Utakmica>();

        [InverseProperty(nameof(Utakmica.GostujucaEkipa))]
        public virtual ICollection<Utakmica> GostujuceUtakmice { get; set; } = new List<Utakmica>();
    }
}
