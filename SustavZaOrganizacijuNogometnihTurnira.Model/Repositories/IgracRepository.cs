using Microsoft.EntityFrameworkCore;
using SustavZaOrganizacijuNogometnihTurnira.Model.Data;

namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class IgracRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public IgracRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Igrac> GetAll()
        {
            return _dbContext.Igraci
                .AsNoTracking()
                .Include(igrac => igrac.Ekipa)
                .OrderBy(igrac => igrac.Prezime)
                .ThenBy(igrac => igrac.Ime)
                .ToList();
        }

        public Igrac? GetById(int id)
        {
            return _dbContext.Igraci
                .AsNoTracking()
                .Include(igrac => igrac.Ekipa)
                .FirstOrDefault(igrac => igrac.IgracId == id);
        }

        public void Add(Igrac igrac)
        {
            _dbContext.Igraci.Add(igrac);
            _dbContext.SaveChanges();
        }

        public void Update(Igrac igrac)
        {
            _dbContext.Igraci.Update(igrac);
            _dbContext.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _dbContext.Igraci.Any(igrac => igrac.IgracId == id);
        }
    }
}
