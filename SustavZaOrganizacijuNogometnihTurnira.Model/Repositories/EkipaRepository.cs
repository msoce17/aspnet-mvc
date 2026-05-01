using Microsoft.EntityFrameworkCore;
using SustavZaOrganizacijuNogometnihTurnira.Model.Data;

namespace SustavZaOrganizacijuNogometnihTurnira.Model.Repositories
{
    public class EkipaRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EkipaRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Ekipa> GetAll()
        {
            return _dbContext.Ekipe
                .AsNoTracking()
                .OrderBy(ekipa => ekipa.Naziv)
                .ToList();
        }

        public Ekipa? GetById(int id)
        {
            return _dbContext.Ekipe
                .AsNoTracking()
                .Include(ekipa => ekipa.Igraci)
                .Include(ekipa => ekipa.PrijaveEkipe)
                .FirstOrDefault(ekipa => ekipa.EkipaId == id);
        }

        public void Add(Ekipa ekipa)
        {
            _dbContext.Ekipe.Add(ekipa);
            _dbContext.SaveChanges();
        }

        public void Update(Ekipa ekipa)
        {
            _dbContext.Ekipe.Update(ekipa);
            _dbContext.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _dbContext.Ekipe.Any(ekipa => ekipa.EkipaId == id);
        }
    }
}
