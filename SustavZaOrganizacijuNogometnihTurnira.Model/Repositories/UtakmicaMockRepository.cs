namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class UtakmicaMockRepository
    {
        private static readonly List<Utakmica> Utakmice =
        [
            new()
            {
                UtakmicaId = 1,
                TurnirId = 1,
                DomacaEkipaId = 1,
                GostujucaEkipaId = 2,
                DatumVrijeme = new DateTime(2024, 7, 3, 18, 0, 0),
                StadionId = 1,
                SudacId = 1,
                GoloviDomace = 2,
                GoloviGosta = 1,
                Status = "Završena",
                Napomena = "Dobra utakmica, puno navijača."
            },
            new()
            {
                UtakmicaId = 2,
                TurnirId = 2,
                DomacaEkipaId = 3,
                GostujucaEkipaId = 4,
                DatumVrijeme = new DateTime(2024, 12, 3, 18, 0, 0),
                StadionId = 2,
                SudacId = 2,
                GoloviDomace = 1,
                GoloviGosta = 1,
                Status = "Završena",
                Napomena = "Izjednačena utakmica."
            },
            new()
            {
                UtakmicaId = 3,
                TurnirId = 3,
                DomacaEkipaId = 1,
                GostujucaEkipaId = 3,
                DatumVrijeme = new DateTime(2024, 3, 3, 18, 0, 0),
                StadionId = 3,
                SudacId = 3,
                GoloviDomace = 0,
                GoloviGosta = 2,
                Status = "Završena",
                Napomena = "Dobra utakmica, ali domaćini nisu uspjeli postići gol."
            }
        ];

        public IEnumerable<Utakmica> GetAll()
        {
            return Utakmice;
        }

        public Utakmica? GetById(int id)
        {
            return Utakmice.FirstOrDefault(utakmica => utakmica.UtakmicaId == id);
        }
    }
}
