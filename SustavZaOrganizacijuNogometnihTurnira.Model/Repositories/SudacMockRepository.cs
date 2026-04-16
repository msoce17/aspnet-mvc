namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class SudacMockRepository
    {
        private static readonly List<Sudac> Sudci =
        [
            new()
            {
                SudacId = 1,
                Ime = "Marko",
                Prezime = "Horvat",
                Licenca = "UEFA-A"
            },
            new()
            {
                SudacId = 2,
                Ime = "Ivan",
                Prezime = "Milic",
                Licenca = "UEFA-B"
            },
            new()
            {
                SudacId = 3,
                Ime = "Petar",
                Prezime = "Novak",
                Licenca = "UEFA-A"
            }
        ];

        public IEnumerable<Sudac> GetAll()
        {
            return Sudci;
        }

        public Sudac? GetById(int id)
        {
            return Sudci.FirstOrDefault(sudac => sudac.SudacId == id);
        }
    }
}
