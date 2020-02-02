using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Flats.Gui.Data
{
    public abstract class CrudServiceBase<T> where T : class
    {
        public CrudServiceBase(FlatsDbContext dbContext)
        {
            DbContext = dbContext;
        }

        protected FlatsDbContext DbContext { get; }

        public virtual Task<T[]> GetAsync()
        {
            return DbContext.Set<T>().ToArrayAsync();
        }

        public virtual async Task<T> GetAsync(string id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task DeleteAsync(string id)
        {
            var site = await GetAsync(id);

            if (site is null)
                return;

            DbContext.Set<T>().Remove(site);
            await DbContext.SaveChangesAsync();
        }

        public virtual async Task<T> CreateAsync(T site)
        {
            DbContext.Add(site);
            await DbContext.SaveChangesAsync();
            return site;
        }

        public virtual async Task<T> UpdateAsync(T site)
        {
            DbContext.Update(site);
            await DbContext.SaveChangesAsync();
            return site;
        }
    }
}
