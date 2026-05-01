using System.ComponentModel.DataAnnotations;
using SustavZaOrganizacijuNogometnihTurnira.Model;

namespace SustavZaOrganizacijuNogometnihTurnira.Models
{
    public class IgracFormViewModel
    {
        public int? IgracId { get; set; }

        [Required(ErrorMessage = "Ime igrača je obavezno.")]
        [StringLength(60, ErrorMessage = "Ime igrača može imati najviše 60 znakova.")]
        [Display(Name = "Ime")]
        public string Ime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Prezime igrača je obavezno.")]
        [StringLength(60, ErrorMessage = "Prezime igrača može imati najviše 60 znakova.")]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; } = string.Empty;

        [Range(1, 99, ErrorMessage = "Broj dresa mora biti između 1 i 99.")]
        [Display(Name = "Broj dresa")]
        public int BrojDresa { get; set; } = 1;

        [Required(ErrorMessage = "Pozicija je obavezna.")]
        [StringLength(40, ErrorMessage = "Pozicija može imati najviše 40 znakova.")]
        [Display(Name = "Pozicija")]
        public string Pozicija { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Datum rođenja")]
        public DateTime DatumRodjenja { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Država je obavezna.")]
        [StringLength(60, ErrorMessage = "Država može imati najviše 60 znakova.")]
        [Display(Name = "Država")]
        public string Drzava { get; set; } = string.Empty;

        [Range(1.00, 2.50, ErrorMessage = "Visina mora biti između 1.00 i 2.50 m.")]
        [Display(Name = "Visina")]
        public decimal Visina { get; set; } = 1.80m;

        [Range(1, int.MaxValue, ErrorMessage = "Odaberi ekipu.")]
        [Display(Name = "Ekipa")]
        public int EkipaId { get; set; }

        public IEnumerable<Ekipa> Ekipe { get; set; } = new List<Ekipa>();
    }
}
