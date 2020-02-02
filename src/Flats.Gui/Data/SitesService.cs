using Flats.Gui.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flats.Gui.Data
{
    public class SitesService : CrudServiceBase<Site>
    {
        public SitesService(FlatsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
