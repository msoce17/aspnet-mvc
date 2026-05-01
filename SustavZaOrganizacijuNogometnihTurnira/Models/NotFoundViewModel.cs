namespace SustavZaOrganizacijuNogometnihTurnira.Models
{
    public class NotFoundViewModel
    {
        public string Title { get; set; } = "Zapis nije pronađen";
        public string Message { get; set; } = "Traženi zapis ne postoji ili više nije dostupan.";
        public string BackLinkText { get; set; } = "Povratak na popis";
        public string BackController { get; set; } = "Home";
        public string BackAction { get; set; } = "Index";
    }
}
