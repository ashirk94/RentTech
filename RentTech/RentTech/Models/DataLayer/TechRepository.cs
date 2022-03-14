using Microsoft.EntityFrameworkCore;
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
        public IQueryable<TechItem> TechItems
        {
            get
            {
                return _context.TechItem.Include(t => t.Owner)
                    .ThenInclude(t => t.Reviews)
                    .Include(t => t.Tags);
            }
        }


        public async Task Delete(int id)
        {
            TechItem item = await _context.TechItem.FindAsync(id);
            _context.TechItem.Remove(item);
        }

        public async Task<TechItem> GetById(int id)
        {
            return await _context.TechItem.FindAsync(id);
        }

        public async Task Insert(TechItem obj)
        {
            await _context.TechItem.AddAsync(obj);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(TechItem obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
