using Microsoft.EntityFrameworkCore;
using SustavZaOrganizacijuNogometnihTurnira.Model.Data;

namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class PrijavaEkipeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PrijavaEkipeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PrijavaEkipe> GetAll()
        {
            return _dbContext.PrijaveEkipe
                .AsNoTracking()
                .Include(prijava => prijava.Turnir)
                .Include(prijava => prijava.Ekipa)
                .OrderBy(prijava => prijava.DatumPrijave)
                .ToList();
        }

        public PrijavaEkipe? GetById(int id)
        {
            return _dbContext.PrijaveEkipe
                .AsNoTracking()
                .Include(prijava => prijava.Turnir)
                .Include(prijava => prijava.Ekipa)
                .FirstOrDefault(prijava => prijava.PrijavaEkipeId == id);
        }
    }
}
