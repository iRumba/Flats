using Flats.Gui.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flats.Gui.Data
{
    public class FlatsService : CrudServiceBase<Flat>
    {
        public FlatsService(FlatsDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<Flat[]> GetAsync()
        {
            return DbContext.Flats
                .Include(x => x.FlatSites)
                .ThenInclude(x => x.Site)
                .ToArrayAsync();
        }

        public override Task<Flat> GetAsync(string id)
        {
            return DbContext.Flats
                .Include(x => x.FlatSites)
                .ThenInclude(x => x.Site)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
