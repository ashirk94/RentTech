using RentTech.Models.DomainModels;

namespace RentTech.Models.DataLayer
{
    public class FakeTechRepo : ITechRepository
    {
        List<TechItem> items = new List<TechItem>();

        public IQueryable<TechItem> TechItems
        {
            get { return items.AsQueryable<TechItem>(); }
        }

        public async Task<TechItem> GetById(int id)
        {
            return await Task.Run(() => items[id]);
        }

        public async Task Insert(TechItem item)
        {
            await Task.Run(() => items.Add(item));
        }

        public async Task Delete(int id)
        {
            TechItem item = await Task.Run(() => items[id]);
            items.Remove(item);
        }

        public async Task Update(TechItem item)
        {
            TechItem myPost = await Task.Run(() => items[item.TechItemId]);
            await Task.Run(() => myPost = item);
        }

        public async Task Save()
        {
            await Task.Run(() => Console.WriteLine("Saved"));
        }
    }
}
