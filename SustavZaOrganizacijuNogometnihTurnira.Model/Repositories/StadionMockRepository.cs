namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class StadionMockRepository
    {
        private static readonly List<Stadion> Stadioni =
        [
            new()
            {
                StadionId = 1,
                Naziv = "Stadion Maksimir",
                Grad = "Zagreb",
                Kapacitet = 35000
            },
            new()
            {
                StadionId = 2,
                Naziv = "Stadion Oljica",
                Grad = "Split",
                Kapacitet = 18000
            },
            new()
            {
                StadionId = 3,
                Naziv = "Gradski stadion",
                Grad = "Rijeka",
                Kapacitet = 20000
            }
        ];

        public IEnumerable<Stadion> GetAll()
        {
            return Stadioni;
        }

        public Stadion? GetById(int id)
        {
            return Stadioni.FirstOrDefault(stadion => stadion.StadionId == id);
        }
    }
}
