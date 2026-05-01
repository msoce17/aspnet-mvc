using Microsoft.EntityFrameworkCore;
using SustavZaOrganizacijuNogometnihTurnira.Model.Data;

namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class SudacRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SudacRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Sudac> GetAll()
        {
            return _dbContext.Sudci
                .AsNoTracking()
                .OrderBy(sudac => sudac.Prezime)
                .ThenBy(sudac => sudac.Ime)
                .ToList();
        }

        public Sudac? GetById(int id)
        {
            return _dbContext.Sudci
                .AsNoTracking()
                .Include(sudac => sudac.Utakmice)
                .FirstOrDefault(sudac => sudac.SudacId == id);
        }
    }
}
