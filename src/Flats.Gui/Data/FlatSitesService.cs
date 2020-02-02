using Flats.Gui.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Flats.Gui.Data
{
    public class FlatSitesService
    {
        private readonly FlatsDbContext _dbContext;

        public FlatSitesService(FlatsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FlatSite> GenerateFlatSiteAsync(string url)
        {
            var site = await _dbContext.Sites
                .Where(x => url.StartsWith(x.UrlTemplate.Substring(0, x.UrlTemplate.IndexOf("{id}"))))
                .Where(x => url.EndsWith(x.UrlTemplate.Substring(x.UrlTemplate.IndexOf("{id}") + 4, x.UrlTemplate.Length)))
                .FirstOrDefaultAsync();

            if (site is null)
                return null;

            var indexOfId = site.UrlTemplate.IndexOf("{id}");
            var urlBeforeId = site.UrlTemplate.Substring(0, indexOfId);
            var urlAfterId = site.UrlTemplate.Substring(indexOfId + 4);

            var foreignKey = url.Replace(urlBeforeId, "");
            if (!string.IsNullOrWhiteSpace(urlAfterId))
                foreignKey = foreignKey.Replace(urlAfterId, "");

            return new FlatSite
            {
                Site = site,
                ForeignKey = foreignKey
            };
        }
    }
}
