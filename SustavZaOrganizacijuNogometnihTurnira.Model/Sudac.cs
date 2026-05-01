using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SustavZaOrganizacijuNogometnihTurnira.Model
{
    [Table("Sudci")]
    public class Sudac
    {
        [Key]
        public int SudacId { get; set; }

        [Required]
        [StringLength(60)]
        public string Ime { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        public string Prezime { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Licenca { get; set; } = string.Empty;

        [InverseProperty(nameof(Utakmica.Sudac))]
        public virtual ICollection<Utakmica> Utakmice { get; set; } = new List<Utakmica>();
    }
}
