using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flats.Gui
{
    public class RuntimeDbContextFactory : IDesignTimeDbContextFactory<FlatsDbContext>
    {
        public FlatsDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<FlatsDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=flats_db;Trusted_Connection=True;MultipleActiveResultSets=true", options =>
                {

                })
                .Options;

            var dbContext = new FlatsDbContext(options);

            //dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
