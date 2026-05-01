using Microsoft.EntityFrameworkCore;
using SustavZaOrganizacijuNogometnihTurnira.Model.Data;

namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class TurnirRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TurnirRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Turnir> GetAll()
        {
            return _dbContext.Turniri
                .AsNoTracking()
                .OrderBy(turnir => turnir.DatumPocetka)
                .ToList();
        }

        public Turnir? GetById(int id)
        {
            return _dbContext.Turniri
                .AsNoTracking()
                .Include(turnir => turnir.PrijaveEkipe)
                .Include(turnir => turnir.Utakmice)
                .FirstOrDefault(turnir => turnir.TurnirId == id);
        }
    }
}
