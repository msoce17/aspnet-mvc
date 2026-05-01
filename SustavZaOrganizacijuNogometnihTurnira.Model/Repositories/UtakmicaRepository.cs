using Microsoft.EntityFrameworkCore;
using SustavZaOrganizacijuNogometnihTurnira.Model.Data;

namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class UtakmicaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UtakmicaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Utakmica> GetAll()
        {
            return _dbContext.Utakmice
                .AsNoTracking()
                .Include(utakmica => utakmica.Turnir)
                .Include(utakmica => utakmica.DomacaEkipa)
                .Include(utakmica => utakmica.GostujucaEkipa)
                .Include(utakmica => utakmica.Stadion)
                .Include(utakmica => utakmica.Sudac)
                .OrderBy(utakmica => utakmica.DatumVrijeme)
                .ToList();
        }

        public Utakmica? GetById(int id)
        {
            return _dbContext.Utakmice
                .AsNoTracking()
                .Include(utakmica => utakmica.Turnir)
                .Include(utakmica => utakmica.DomacaEkipa)
                .Include(utakmica => utakmica.GostujucaEkipa)
                .Include(utakmica => utakmica.Stadion)
                .Include(utakmica => utakmica.Sudac)
                .FirstOrDefault(utakmica => utakmica.UtakmicaId == id);
        }
    }
}
