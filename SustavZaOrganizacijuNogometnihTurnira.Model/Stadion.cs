using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    [Table("Stadioni")]
    public class Stadion
    {
        [Key]
        public int StadionId { get; set; }

        [Required]
        [StringLength(120)]
        public string Naziv { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Grad { get; set; } = string.Empty;

        [Range(1, 100000)]
        public int Kapacitet { get; set; }

        [InverseProperty(nameof(Utakmica.Stadion))]
        public virtual ICollection<Utakmica> Utakmice { get; set; } = new List<Utakmica>();
    }
}
