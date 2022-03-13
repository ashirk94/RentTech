using RentTech.Models.DomainModels;

namespace RentTech.Models.DataLayer
{
    public interface ITechRepository
    {
        public IQueryable<TechItem> TechItems { get; }
        public Task<TechItem> GetById(int id);
        public Task Insert(TechItem obj);
        public Task Update(TechItem obj);
        public Task Delete(int id);
        public Task Save();
    }
}
