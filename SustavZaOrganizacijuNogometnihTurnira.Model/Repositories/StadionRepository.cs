using Microsoft.EntityFrameworkCore;
using SustavZaOrganizacijuNogometnihTurnira.Model.Data;

namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class StadionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StadionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Stadion> GetAll()
        {
            return _dbContext.Stadioni
                .AsNoTracking()
                .OrderBy(stadion => stadion.Naziv)
                .ToList();
        }

        public Stadion? GetById(int id)
        {
            return _dbContext.Stadioni
                .AsNoTracking()
                .Include(stadion => stadion.Utakmice)
                .FirstOrDefault(stadion => stadion.StadionId == id);
        }
    }
}
