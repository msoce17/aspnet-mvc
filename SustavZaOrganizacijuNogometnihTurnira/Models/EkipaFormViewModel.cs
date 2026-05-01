using System.ComponentModel.DataAnnotations;

namespace SustavZaOrganizacijuNogometnihTurnira.Models
{
    public class EkipaFormViewModel
    {
        public int? EkipaId { get; set; }

        [Required(ErrorMessage = "Naziv ekipe je obavezan.")]
        [StringLength(100, ErrorMessage = "Naziv ekipe može imati najviše 100 znakova.")]
        [Display(Name = "Naziv")]
        public string Naziv { get; set; } = string.Empty;

        [Required(ErrorMessage = "Grad je obavezan.")]
        [StringLength(100, ErrorMessage = "Grad može imati najviše 100 znakova.")]
        [Display(Name = "Grad")]
        public string Grad { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Datum osnutka")]
        public DateTime DatumOsnutka { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Ime trenera je obavezno.")]
        [StringLength(100, ErrorMessage = "Ime trenera može imati najviše 100 znakova.")]
        [Display(Name = "Trener")]
        public string TrenerIme { get; set; } = string.Empty;

        [Range(0, 99, ErrorMessage = "Broj igrača mora biti između 0 i 99.")]
        [Display(Name = "Broj igrača")]
        public int BrojIgraca { get; set; }

        [Required(ErrorMessage = "Kontakt je obavezan.")]
        [StringLength(50, ErrorMessage = "Kontakt može imati najviše 50 znakova.")]
        [Display(Name = "Kontakt")]
        public string Kontakt { get; set; } = string.Empty;
    }
}
