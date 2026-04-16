namespace SustavZaOrganizacijuNogometnihTurnira.Models
{
    public class BreadcrumbItem
    {
        public string Text { get; set; } = string.Empty;
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public IDictionary<string, string>? RouteValues { get; set; }
        public bool IsActive { get; set; }
    }
}
