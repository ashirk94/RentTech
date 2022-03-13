using RentTech.Data;
using RentTech.Models.DomainModels;

namespace RentTech.Models.DataLayer
{
    public class TechRepository : ITechRepository
    {
        private readonly ApplicationDbContext _context;

        public TechRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<TechItem> TechItems => _context.;

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TechItem> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(TechItem obj)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

        public Task Update(TechItem obj)
        {
            throw new NotImplementedException();
        }
    }
}
